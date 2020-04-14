using Application.Common.Interfaces;
using Application.Reservations.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Reservations.Queries
{
    public class GetAllReservationsQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationDto>>
        {
            private readonly IRepositoryWrapper repository;

            public GetAllReservationsQueryHandler(IRepositoryWrapper repo)
            {
                repository = repo;
            }


            public async Task<IEnumerable<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
            {
              //return await repository.Reservation.FindAllAsync();
              return await repository.Reservation.GetReservationsAsync();
            }
        }
    }
}
