using FuelService.Core;
using FuelService.Core.Common;
using FuelService.Core.Services;
using FuelService.Data.Contexts;
using FuelService.Data.Repositories;
using FuelService.Jobs;
using Ninject.Modules;
using Quartz;
using System;
using System.Configuration;
using Topshelf;
using Topshelf.Ninject;
using Topshelf.Quartz;
using Topshelf.Quartz.Ninject;

namespace FuelService
{
    class Program
    {
        static void Main(string[] args)
        {                        
            HostFactory.Run(c =>
            {
                c.UseNinject(new NinjctModules());

                c.Service<FuelService>(s =>
                {
                    s.ConstructUsingNinject();

                    s.WhenStarted((service, control) => service.Start());
                    s.WhenStopped((service, control) => service.Stop());
                    
                    s.UseQuartzNinject();

                    s.ScheduleQuartzJob(q =>
                        q.WithJob(() =>
                            JobBuilder.Create<FuelJob>().Build())
                            .AddTrigger(() =>
                                TriggerBuilder.Create()
                                    .WithSimpleSchedule(builder => builder.WithIntervalInSeconds(60).RepeatForever()).Build())                                    
                        );
                });
            });   
        }
    }    

    public class NinjctModules : NinjectModule
    {
        public override void Load()
        {
            Bind<DataContext>().ToMethod(c=>new DataContext());
            Bind<IFuelRepository>().To<FuelRepository>().InTransientScope();            
            Bind<IJsonReader>().To<JsonReader>().InTransientScope();
            Bind<IHttpClient>().To<HttpClient>().InTransientScope();            
            Bind<IFuelService>().To<Core.Services.FuelService>().InTransientScope()
                                                                .WithConstructorArgument("getLastDays", Convert.ToInt32(ConfigurationManager.AppSettings["getLastDays"]))
                                                                .WithConstructorArgument("chunkSize", Convert.ToInt32(ConfigurationManager.AppSettings["chunkSize"]))
                                                                .WithConstructorArgument("serviceApi", ConfigurationManager.AppSettings["serviceApi"]);

        }
    }
}
