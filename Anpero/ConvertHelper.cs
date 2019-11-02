using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anpero
{
   public static class ConvertHelper
    {
        public static DateTime ConvertTodateTime(string inputString)
        {
            DateTime datetime = new DateTime();
            try
            {
                datetime = DateTime.ParseExact(inputString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (Exception)
            {

                datetime = DateTime.ParseExact(inputString, "dd/MM/yyyy h:mm tt",  CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            return datetime;
        }
    }
}
