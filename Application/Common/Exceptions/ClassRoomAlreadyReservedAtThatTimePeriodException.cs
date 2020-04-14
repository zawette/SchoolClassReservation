using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class ClassRoomAlreadyReservedAtThatTimePeriodException : Exception
    {
        public ClassRoomAlreadyReservedAtThatTimePeriodException():base("Class room is already reserved at that time period")
        {
        }
    }
}
