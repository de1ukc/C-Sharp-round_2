
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApp1
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        public Node<T> Head; // голову 
        private int count = 0; // количество 
        public  int pnt = 0; // положение курсора

        public int Count { get => count; }
        /// <summary>
        /// 
        /// </summary>
        public MyCustomCollection()
        {
            Head = null;
        }

        public MyCustomCollection(T value)
        {
            this.Add(value);
        }

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.Head = new Node<T>(item);
                count++;
            }
            else
            {
                Node<T> cur = this.Head;
                while (cur.right != null)
                {
                    cur = cur.right;
                }
                cur.right = new Node<T>(item);
                count++;
            }
        }

        public T Current()
        {
            return this[pnt];
        }

        public void Next()
        {
            this.pnt++;
        }

        public void Reset()
        {
            pnt = 0;
        }

        public T RemoveCurrent()
        {
            if (pnt == 0)
            {
                Node<T> buff = Head;
                Head = Head.right;
                count--;
                return buff.Date;
            }
            else if (pnt >=1 &&  pnt < this.Count)
            {
                var buff = this[pnt];
                Node<T> cur = Head;
                int i = 0;
                while (i != pnt - 1)
                {
                    cur = cur.right;
                    i++;
                }

                if (cur.right.right != null)
                {
                    cur.right = cur.right.right;
                    count--;
                }
                else
                {
                    cur.right = null;
                }
                return buff;
            }
            return default; 
        }

        public void Remove(T item) 
        {
            Node<T> cur = Head;
            int i = 0;
            bool flag = false;
            while (cur != null)
            {
                if (Functions<T>.Comp(cur.Date, item) == 0) {flag = true;break;}
                i++;
                cur = cur.right;
            }

            if (!flag)
            {
                throw new MyOwnExceptions("Элемента нет в коллекции");
            }

            if (Functions<T>.Comp(Head.Date, item) == 0){ Head = null; count--; return;}
            i--; // перехожу на предыдущий к удаляемому
            cur = Head;
            while (i != 0)
            {
                cur = cur.right;  // перехожу на предыдущий к удаляемому
                i--;
            }
            if (cur.right.right != null)
            {
                cur.right = cur.right.right;
            }
            else
            {
                cur.right = null;
            }

            count--;
        }

        public T this[int index] // так делать нельзя
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    Node<T> cur = Head;
                    
                    while (index != 0)
                    {
                        cur = cur.right;
                        index--;
                    }
                    
                    return cur.Date;
                }
            }

            set
            {
                if (index >= this.Count)
                {
                    Console.WriteLine("Так делать не хорошо");
                }
                else
                {
                    Node<T> cur = Head;
                    
                    while (index != -1)
                    {
                        cur = cur.right;
                        index--;
                    }

                    cur.Date = value;
                    count++;
                }
            }
        }
    }

    public class Node<T>
    {
        private T date;
        public Node<T> right, left;

        public Node(T value)
        {
            this.date = value;
        }

        public T Date
        {
            get => date;
            set => date = value;
        }
    }
}