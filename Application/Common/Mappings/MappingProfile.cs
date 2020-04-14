using Application.Courss.DTO;
using Application.Instructors.DTO;
using Application.Reservations.DTO;
using Application.Salles.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Mappings
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cours, CoursDto>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Salle, SalleDto>();
            CreateMap<Reservation, ReservationDto>();

        }
    }
}
