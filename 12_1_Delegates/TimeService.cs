using System;
using System.Collections.Generic;
using System.Text;

namespace _12_1_Delegates
{
    public class TimeService
    {
        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        public void ShowDay()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }

        public double TriangleArea(double a, double h)
        {
            return 0.5 * a * h;
        }

        public double RectangleArea(double a, double b)
        {
            return a * b;
        }
    }
}
