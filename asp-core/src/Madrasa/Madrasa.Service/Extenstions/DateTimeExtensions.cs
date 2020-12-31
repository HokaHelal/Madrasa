using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Service.Extenstions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToDoB(this int age)
        {
            return DateTime.Today.AddYears(-age);
        }
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Now;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
