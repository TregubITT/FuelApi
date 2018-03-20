using FuelService.Core.Services;
using Quartz;
using System;

namespace FuelService.Jobs
{
    public class FuelJob : IJob
    {
        private readonly IFuelService _fuel;
        public FuelJob(IFuelService fuel)
        {
            _fuel = fuel;
        }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("The current time is: {0}", DateTime.Now);            
            _fuel.Process();
        }
    }
}
