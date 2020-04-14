using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class FieldUsedInReservationException : Exception
    {
        public FieldUsedInReservationException(): base()
        {

        }

        public FieldUsedInReservationException(string fieldValue) : base($"{fieldValue} is used in a Reservation")
        {

        }
    }
}
