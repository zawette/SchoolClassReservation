using Application.Common.Exceptions;
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
    public class GetReservationQuery : IRequest<ReservationDto>
    {
        public Guid Id { get; set; }

        public class GetAllReservationsQueryHandler : IRequestHandler<GetReservationQuery,ReservationDto>
        {
            private readonly IRepositoryWrapper repository;

            public GetAllReservationsQueryHandler(IRepositoryWrapper repo)
            {
                repository = repo;
            }


            public async Task<ReservationDto> Handle(GetReservationQuery request, CancellationToken cancellationToken)
            {
              var entity= await repository.Reservation.GetReservationAsync(request.Id);
                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                return entity;
            }
        }
    }
}
