using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands
{
    public class UpdateReservationCommand : IRequest
    {
        public Guid Id { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public Guid instructorId { get; set; }
        public Guid salleId { get; set; }
        public Guid coursId { get; set; }



        public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
        {
            private readonly IRepositoryWrapper repository;

            public UpdateReservationCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
            {
                var entity = await repository.Reservation.FindByCondition(r => r.Id.Equals(request.Id)).FirstOrDefaultAsync();
                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                var ClassRoomIsReserved = await repository.Reservation.ClassRoomIsReserved(new DateTimeRange(request.dateDebut, request.dateFin), request.salleId, request.Id);
                var InstructorIsAlreadyAssigned = await repository.Reservation.InstructorIsAlreadyAssigned(new DateTimeRange(request.dateDebut, request.dateFin), request.instructorId, request.Id);

                if (ClassRoomIsReserved)
                {
                    throw new ClassRoomAlreadyReservedAtThatTimePeriodException();
                }

                if (InstructorIsAlreadyAssigned)
                {
                    throw new InstructorAlreadyAssignedAtThatTimePeriodException();
                }

                entity.dateDebut = request.dateDebut;
                entity.dateFin = request.dateFin;
                entity.instructorId = request.instructorId;
                entity.salleId = request.salleId;
                entity.coursId = request.coursId;

                repository.Reservation.Update(entity);
                await repository.SaveAsync();

                return Unit.Value; //this represents a void type , i'll need to return a reservation object later ; so this is temporary
            }
        }
    }
}
