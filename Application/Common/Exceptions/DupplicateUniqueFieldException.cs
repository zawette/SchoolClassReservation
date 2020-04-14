using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class DupplicateUniqueFieldException : Exception
    {
        public DupplicateUniqueFieldException():base()
        {
        }

        public DupplicateUniqueFieldException(string fieldValue):base($"{fieldValue} already exists")
        {

        }
    }
}
