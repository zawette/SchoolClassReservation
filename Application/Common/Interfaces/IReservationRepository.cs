using Application.Reservations.DTO;
using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IReservationRepository : IRepositoryBase<Reservation>
    {
        public Task<IEnumerable<ReservationDto>> GetReservationsAsync();
        public Task<bool> ClassRoomIsReserved(DateTimeRange dateTimeRange, Guid salleId, Guid reservationId = default(Guid));
        public Task<bool> InstructorIsAlreadyAssigned(DateTimeRange dateTimeRange, Guid instructorId, Guid reservationId = default(Guid));
        public Task<ReservationDto> GetReservationAsync(Guid Id);



    }
}
