using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace IntegralLib
{
    public class Integral
    {
        public double IntSin(bool Timeflag)
        {
            var sw = Stopwatch.StartNew();
            const double epsilon = 0.00000001;
            double i = 0;
            double ans = 0;
            while (i < 1.0 )
            {
                //Console.WriteLine(Math.Sin(i));
                ans += Math.Sin(i) * epsilon;
                i += epsilon;
            }
            sw.Stop();
            if (Timeflag)  Console.WriteLine($"Operation time: {sw.Elapsed}");
            return ans;
            
        }
    }

    public class Answers
    {
        public delegate void Ans(double x);

        public event Ans showAns;

        public void ShowAns(double ans)
        {
            this.showAns?.Invoke(ans);
        }
    }
}