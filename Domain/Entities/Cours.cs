using Domain.Common;
using System.Collections.Generic;


namespace Domain.Entities
{
    public class Cours : Entity
    {
        public string designation { get; set; }
        public ICollection<Reservation> reservations { get; set; }
    }
}
