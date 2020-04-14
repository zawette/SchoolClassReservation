using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class InstructorAlreadyAssignedAtThatTimePeriodException : Exception
    {
        public InstructorAlreadyAssignedAtThatTimePeriodException() : base("Instructor Already Assigned at that time period")
        {

        }
    }
}
