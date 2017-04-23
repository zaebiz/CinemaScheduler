using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSchedule.Core.Extensions
{
    public static class StringEx
    {
        public static TimeSpan ConvertToTimeSpan(this string str)
        {
            var parts = str.Split(':');
            if (parts.Length != 2)
                throw new ArgumentException("Некоректно задано время сеанса");

            return new TimeSpan(int.Parse(parts[0]), int.Parse(parts[1]), 0);
        }
    }
}
