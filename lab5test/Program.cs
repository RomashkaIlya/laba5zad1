using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lab5test
{
    internal class Program
    {
        enum Color:byte
        { 
         red = 1,
         green,
         blue,
         orange
        }
        static DayOfWeek GetNextDay(DayOfWeek day)
        {
            if (day < DayOfWeek.Sunday) return day + 1;
            return DayOfWeek.Monday;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("введите номер дня недели");
            //int value = int.Parse(Console.ReadLine());

            //DayOfWeek dayofweek = DayOfWeek.Monday;
            //dayofweek = (DayOfWeek)value;
            //Console.WriteLine(dayofweek);
            //Console.WriteLine((DayOfWeek)3);

            //DayOfWeek NextDay = GetNextDay(dayofweek);
            //Console.WriteLine(NextDay);
            //int str = int.Parse(Console.ReadLine());
            Color color = Color.orange;
            

            //color = (Color)str;

            switch (color)
            {
                case Color.red:
                    break;
                case Color.green:
                    Console.WriteLine("gay");
                    break;
                case Color.blue:
                    break;
                case Color.orange:
                    break;
                default:
                    break;
            }

        }
    }
}
