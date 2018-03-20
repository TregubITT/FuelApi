using FuelService.Core.Services;
using FuelService.Domain.Entities;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
