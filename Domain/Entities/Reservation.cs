using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reservation : Entity
    {
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public Guid instructorId { get; set; }
        public Guid salleId { get; set; }
        public Guid coursId { get; set; }

        public Instructor instructor { get; set; }
        public Salle salle { get; set; }
        public Cours cours { get; set; }

    }
}
