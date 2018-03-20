using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
