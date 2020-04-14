using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Reservations.DTO;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
        {
            private readonly IRepositoryWrapper repository;

            public DeleteReservationCommandHandler(IRepositoryWrapper repo)
            {
                repository = repo;
            }


            public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
            {
                var entity = await repository.Reservation.FindByCondition(r=>r.Id.Equals(request.Id)).FirstOrDefaultAsync();
                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                repository.Reservation.Delete(entity);
                await repository.SaveAsync();
                return Unit.Value;
            }
        }
    }
}
