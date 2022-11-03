using System;
using System.Collections.Generic;
using ConsoleApp1;

namespace lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            User Aleh = new User("Asadchy Aleh Eduardovich",5000,8);
            User Nikolas = new User("Vashkevich Nikolai Vladimirovich",3000,12);
            User Dima = new User("Gotchenya Dmitry Gennadevich",1000,12);
            User Masha = new User("Zyranova Maria Mikchalovna",8000,3);
            User Dasha = new User("Golovko Daria Alexandrovna",6500,7);
           
            List<User> a = new List<User>();
            
            a.Add(Aleh);
            a.Add(Nikolas);
            a.Add(Dima);
            a.Add(Masha);
            a.Add(Dasha);
            
            Bank list = new Bank();
            
            list.arr[Aleh.procent+1].Add(Aleh);
            list.arr[Nikolas.procent+1].Add(Nikolas);
            list.arr[Dima.procent+1].Add(Dima);
            list.arr[Masha.procent+1].Add(Masha);
            list.arr[Dasha.procent+1].Add(Dasha);
            
            //Functions.Names(list);
            Console.WriteLine(Functions.Procent(list));
            Console.WriteLine(Functions.Money(list));
            Functions.Largest(list);
            Console.WriteLine(Functions.Count(list, 6));
            Functions.Group(list);
        }
    }
}