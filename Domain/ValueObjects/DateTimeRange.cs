using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class DateTimeRange
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public DateTimeRange()
        {

        }
        public DateTimeRange(DateTime start, DateTime end )
        {
            Start = start;
            End = end;
        }

        public static bool isOverlapping(DateTimeRange a, DateTimeRange b)
        {
            return a.Start < b.End && b.Start < a.End;
        }

    }
}
