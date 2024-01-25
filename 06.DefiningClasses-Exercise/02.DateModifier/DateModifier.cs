using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    static class DateModifier
    {
        static public int GetDifferenceInDates(string firstDate, string secondDate)
        {

            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            TimeSpan difference = startDate - endDate;

            return Math.Abs(difference.Days);
        }
    }
}
