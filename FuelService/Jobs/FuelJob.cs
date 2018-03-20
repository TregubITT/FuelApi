using FuelService.Core.Services;
using NLog;
using Quartz;
using System;

namespace FuelService.Jobs
{
    public class FuelJob : IJob
    {
        private readonly IFuelService _fuel;
        private readonly ILogger _logger;

        public FuelJob(IFuelService fuel, ILogger logger)
        {
            _logger = logger;
            _fuel = fuel;
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {                
                Console.WriteLine("The current time is: {0}", DateTime.Now);
                _fuel.Process();
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}
