using System;
using System.Threading;
using IntegralLib;

namespace lastLab_11.Properties
{
    public class FirstTaskStart
    {
        public static void Start()
        {
            Answers tool = new Answers();
            Integral integ = new Integral();
            tool.showAns += Show;
            var tuple = new Tuple<Answers, Integral>(tool, integ);
                
            Thread FirstThread = new Thread(new ParameterizedThreadStart(FirstStream));
            FirstThread.Priority = ThreadPriority.Lowest;
            FirstThread.Start(tuple);
                
            Thread SecondThread = new Thread(new ParameterizedThreadStart(SecondStream));
            SecondThread.Priority = ThreadPriority.Highest;
            SecondThread.Start(tuple);
        }

        public static void Show(double x)
        {
            Console.WriteLine($"Answer = {x}");
        }

        public static void FirstStream(object obj)
        {
            Console.WriteLine("******************************");
            var tuple = (Tuple<Answers,Integral>)obj;
            Console.WriteLine("The first stream has been started!");
            tuple.Item1.ShowAns(Convert.ToDouble(tuple.Item2.IntSin(true)));
            Console.WriteLine("The first stream has Finished!");
            Console.WriteLine("******************************");
            Thread.Sleep(400);
        }
        
        public static void SecondStream(object obj)
        {
            Console.WriteLine("<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>");
            var tuple = (Tuple<Answers,Integral>)obj;
            Console.WriteLine("The second stream has been started!");
            tuple.Item1.ShowAns(Convert.ToDouble(tuple.Item2.IntSin(true)));
            Console.WriteLine("The second stream has Finished!");
            Console.WriteLine("<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>");
            Thread.Sleep(400);
        }
    }
}