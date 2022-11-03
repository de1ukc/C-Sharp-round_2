using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_8
{
    public class EmployeeComparer<T> : IComparer<T> where T : Employee // почему норм не работает, если просто вписать
    {
       public int Compare(T x, T y)
       {
           //return x.Name == y.Name ? 0 : 1;
           return String.Compare(x.Name, y.Name);
       }
    }
}