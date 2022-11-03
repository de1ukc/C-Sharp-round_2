using System;

namespace ConsoleApp1
{
    public static class Functions<T>  //where T: class
    {
        public static void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public static int namesComp(T first, string name)
        {
            var buff = first as User;
            return  buff.name == name ? 0 : 1;
        }
        
        public static int Comp(T first, T sec)
        {
            var buff1 = first as User;
            var buff2 = first as User;
            if (buff1.name == buff2.name) return 0;
            if (buff1.money > buff2.money) return 1;
            else return -1;
        }
        
        public static int Menu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1.Информация по процентам");
            Console.WriteLine("2.Информация о клиенте");
            Console.WriteLine("3.Пополнить счёт");
            Console.WriteLine("4.Рассчитать сумму");
            Console.WriteLine("0.Выход");
            var key = Int32.Parse(Console.ReadLine());
            while (key > 4 || key < 0)
            {
                Console.WriteLine("Дуралей, выбери правильный вариант заново\n");
                key = Int32.Parse(Console.ReadLine());
            }

            return key;
        }
        
        public static void Search(MyCustomCollection<User> a, string name)
        {
            int i = 0;
            Node<User> cur = a.Head;
            bool flag = false;
            while (i < a.Count)
            {
                if (Functions<User>.namesComp(cur.Date, name ) == 0)
                {
                    Console.WriteLine($"UserName: {cur.Date.name}");
                    Console.WriteLine($"UserProcent: {cur.Date.procent}");
                    Console.WriteLine($"UserMoney: {cur.Date.money}");
                    flag = true;
                }
                cur = cur.right;
                i++;
            }
            if (!flag) Console.WriteLine("Клиента с таким именем не существует.\n");
        }

       public static void search(Bank us, int procent)
        {
            int i = us.arr[procent + 1].Count;
            Node<User> cur = us.arr[procent + 1].Head;
            while (i != 0)
            {
                Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine($"UserName: {cur.Date.name}");
                Console.WriteLine($"UserProcent: {cur.Date.procent}");
                Console.WriteLine($"UserMoney: {cur.Date.money}");
                Console.WriteLine("||||||||||||||||||||||||||||||||||||||");
                cur = cur.right;
                i--;
            }
        }

        public static void Money(MyCustomCollection<User> a, string name, int money)
        {
            int i = 0;
            Node<User> cur = a.Head;
            bool flag = false;
            while (i < a.Count)
            {
                if (Functions<User>.namesComp(cur.Date, name ) == 0)
                {
                    flag = true;
                    break;
                }
                cur = cur.right;
                i++;
            }
            if (!flag) Console.WriteLine("Клиента с таким именем не существует.\n");
            cur.Date.money += money;
            Console.WriteLine("Операция завершена\n");
        }
        
        public static void SUM(MyCustomCollection<User> a)
        {
            int i = 0;
            double Sum = 0;
            while (i < a.Count)
            {
                Sum += a[i].money * a[i].procent / 100;
                i++;
            }
            Console.WriteLine($"Sum = {Sum}");
        }
        
    }
    
    public class MyOwnExceptions : Exception
    {
        public MyOwnExceptions(string message) : base(message)
        {
        }
    }
    
}