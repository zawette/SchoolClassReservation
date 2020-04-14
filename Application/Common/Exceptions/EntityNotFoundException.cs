using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException():base("entity not found")
        {

        }

        public EntityNotFoundException(string typeName) : base($"{typeName} not found")
        {
        }
    }
}
