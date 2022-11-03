using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

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
        public  MyCustomCollection<MyCustomCollection<User>> arr = new MyCustomCollection<MyCustomCollection<User>>();
        public  MyCustomCollection<int>  list = new MyCustomCollection<int>();

        public delegate void Registration(string s,string c);
        public event Registration bank /*= delegate(string s,String c) { }*/;
        public Bank()
        {
            int i = 0;
            while (i < 101)
            {
                list.Add(i);
                i++;
                arr.Add(new MyCustomCollection<User>());
            }
        }

        public void AddUser(User a)
        {
           this.arr[a.procent+1].Add(a); 
           bank?.Invoke(a.name,"добавлен");
        }
    }

    public class Journal
    {
        MyCustomCollection<(String,String)> jrnl = new MyCustomCollection<(string, string)>();

        public void rgstr(String name,String move)
        {
            Console.WriteLine("Пользователь {0} был {1}",name,move);
            jrnl.Add((name,move));
        }
    }
}