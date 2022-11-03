using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public void hello(string name, string day)
        {
            Console.WriteLine("Hello {0} , its good {1}",name,day);
        }

        static void Main(string[] args)
        {
            User Aleh = new User("Asadchy Aleh Eduardovich",5000,8);
            User Nikolas = new User("Vashkevich Nikolai Vladimirovich",3000,12);
            User Dima = new User("Gotchenya Dmitry Gennadevich",1000,2);
            User Masha = new User("Zyranova Maria Mikchalovna",8000,3);
            User Dasha = new User("Golovko Daria Alexandrovna",6500,7);
            MyCustomCollection<User> a = new MyCustomCollection<User>(Aleh);
            
            a.Add(Nikolas);
            a.Add(Dima); 
            a.Add(Masha); 
            a.Add(Dasha);
            
            Bank list = new Bank();
            
            //list.arr[Aleh.procent+1].Add(Aleh);
            list.arr[Nikolas.procent+1].Add(Nikolas);
            list.arr[Dima.procent+1].Add(Dima);
            list.arr[Masha.procent+1].Add(Masha);
            list.arr[Dasha.procent+1].Add(Dasha);
            
            Journal inf = new Journal();
            list.bank += inf.rgstr;
            
            list.AddUser(Aleh);
            
            while (true)
            {
                switch (Functions<User>.Menu())
                {
                    case 1:
                        Console.WriteLine("Введите процент:"); Functions<User>.search(list,Int32.Parse(Console.ReadLine())); break;
                    case 2: 
                        Console.WriteLine("Введите имя:"); Functions<User>.Search(a,Console.ReadLine()); break;
                    case 3:
                        Console.WriteLine("Введите имя и сумму:"); Functions<User>.Money(a,Console.ReadLine(),Int32.Parse(Console.ReadLine()));break;
                    case 4:
                        Functions<User>.SUM(a); break;
                    case 0: Environment.Exit(0); break;
                }
            }
            
            
            a.Remove(Nikolas);
            try
            {
                a.Remove(Nikolas);
            }
            catch (MyOwnExceptions e)
            {
                 Console.WriteLine(e);
                 Console.ReadLine();
            }
        }
    }
}