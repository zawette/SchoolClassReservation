using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Courss.DTO;
using Application.Salles.DTO;
using Application.Instructors.DTO;
using System.Linq;
using Application.Reservations.DTO;
using Domain.ValueObjects;

namespace Persistance.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        private readonly SchoolClassReservationDbContext _repositoryContext;
        private readonly IMapper _mapper;

        public ReservationRepository(SchoolClassReservationDbContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
        {
            return await FindAll()
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    dateDebut = r.dateDebut,
                    dateFin = r.dateFin,
                    cours = _mapper.Map<CoursDto>(r.cours),
                    instructor = _mapper.Map<InstructorDto>(r.instructor),
                    salle = _mapper.Map<SalleDto>(r.salle)
                }).ToListAsync();
        }

        public async Task<ReservationDto> GetReservationAsync(Guid Id)
        {
            return await FindByCondition(r => r.Id.Equals(Id))
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    dateDebut = r.dateDebut,
                    dateFin = r.dateFin,
                    cours = _mapper.Map<CoursDto>(r.cours),
                    instructor = _mapper.Map<InstructorDto>(r.instructor),
                    salle = _mapper.Map<SalleDto>(r.salle)
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> InstructorIsAlreadyAssigned(DateTimeRange dateTimeRange, Guid instructorId, Guid reservationId = default(Guid))
        {
            var reservations = await FindByCondition(r => r.instructorId.Equals(instructorId) && !r.Id.Equals(reservationId)).ToListAsync();
            return reservations.Any(r => DateTimeRange.isOverlapping(dateTimeRange, new DateTimeRange(r.dateDebut, r.dateFin)));

        }

        public async Task<bool> ClassRoomIsReserved(DateTimeRange dateTimeRange, Guid salleId, Guid reservationId = default(Guid))
        {
            var reservations = await FindByCondition(r => r.salleId.Equals(salleId) && !r.Id.Equals(reservationId)).ToListAsync();
            return reservations.Any(r => DateTimeRange.isOverlapping(dateTimeRange, new DateTimeRange(r.dateDebut, r.dateFin)));
        }
    }
}
