using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace ConsoleApp1
{
    public class User
    {
        public string name;
        public int money;
        public int procent;

        public User()
        {
        }

        public User(string name, int money, int procent)
        {
            this.name = name;
            this.money = money;
            this.procent = procent;
        }
    }

    public class Bank
    {
        public  List<List<User>> arr = new List<List<User>>();
        public  List<int>  list = new List<int>();
        

        public Bank()
        {
            int i = 0;
            while (i < 101)
            {
                list.Add(i);
                i++;
                arr.Add(new List<User>());
                
            }
        }
    }

    public class Functions
    {
        public static void Names(Bank obj)
        {
            var tarifs = from tarif in obj.list
                orderby tarif
                select tarif;

            foreach (var tarif in tarifs)
            {
                Console.WriteLine($"Тариф {tarif}%");
            }
        }

        public static int Procent(Bank obj)
        {
            return (from i in obj.arr from U in i select U.procent).Aggregate((x, y) => x + y);
        }
        
        public static int Money(Bank obj)
        {
            return (from i in obj.arr from U in i select U.money).Aggregate((x, y) => x + y);
        }

        public static void Largest(Bank obj)
        {
            var index = (from i in obj.arr from u in i select u.procent).Max();
            Console.WriteLine("Максимальную процентную ставку имеют пользователи:");
            foreach (var users in obj.arr[index+1])
            {
                Console.WriteLine(users.name);
            }
        }

        public static int Count(Bank obj, int n)
        {
            return (from i in obj.arr from U in i select U).Aggregate(0, (a, b) => { a += b.money > n ? 1 : 0; return a;}); 
          // return (from i in obj.arr from U in i select U.procent).Where(i => i > n).Count();
        }

        public static void Group(Bank obj)
        {
            /*
            var procentGroup = from i in obj.arr
                from u in i
                group u by u.procent;
            */

            var procentGroup = from i in obj.arr
                from u in i
                group u by u.procent into g
                select new {procent = g.Key, names = from user in g select user.name};

            foreach (var g in procentGroup)
            {
                /*
                Console.WriteLine($"{g.Key}%:");
                foreach (var user in g)
                {
                    Console.WriteLine(user.name);
                }
                Console.WriteLine();
                */
                Console.WriteLine($"{g.procent}:");
                foreach (var name in g.names)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
            
        }
    }
}