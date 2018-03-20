using System;

namespace FuelService
{
    public class FuelService
    {
        public bool Start()
        {
            Console.WriteLine("Sample Service Started...");
            return true;
        }
        public bool Stop()
        {
            return true;
        }
    }
}
