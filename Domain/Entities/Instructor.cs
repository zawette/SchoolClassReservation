using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor : Entity
    {
        public string nom { get; set; }
        public ICollection<Reservation> reservations { get; set; }

    }
}
