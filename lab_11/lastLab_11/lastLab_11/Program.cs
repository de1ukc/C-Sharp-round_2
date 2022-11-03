using System;
using System.Threading;
using System.Threading.Tasks;
using IntegralLib;
using lastLab_11.Properties;

namespace lastLab_11
{
    internal class Program
    {
        /*
        public static void Main(string[] args)
        { 
            FirstTaskStart.Start();
        }
        */
        public static async Task Main(string[] args)
        {
            SecondTaskStart.Start();
            return;
        }
    }
}