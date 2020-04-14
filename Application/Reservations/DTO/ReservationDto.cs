using Application.Courss.DTO;
using Application.Instructors.DTO;
using Application.Salles.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reservations.DTO
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public InstructorDto instructor { get; set; }
        public SalleDto salle { get; set; }
        public CoursDto cours { get; set; }
    }
}
