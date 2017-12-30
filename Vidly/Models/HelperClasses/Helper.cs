using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Helper
    {
        public static int GetAge(DateTime dob)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dob.Year;
            if (dob > now.AddYears(-age))
                age--;

            return age;
        }
    }
}