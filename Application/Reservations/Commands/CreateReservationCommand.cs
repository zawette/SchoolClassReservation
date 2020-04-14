using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Reservations.Commands
{
    public class CreateReservationCommand : IRequest
    {
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }
        public Guid instructorId { get; set; }
        public Guid salleId { get; set; }
        public Guid coursId { get; set; }



        public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
        {
            private readonly IRepositoryWrapper repository;

            public CreateReservationCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
            {

                var ClassRoomIsReserved = await repository.Reservation.ClassRoomIsReserved(new DateTimeRange(request.dateDebut, request.dateFin), request.salleId);
                var InstructorIsAlreadyAssigned = await repository.Reservation.InstructorIsAlreadyAssigned(new DateTimeRange(request.dateDebut, request.dateFin), request.instructorId);

                if (ClassRoomIsReserved)
                {
                    throw new ClassRoomAlreadyReservedAtThatTimePeriodException();
                }

                if (InstructorIsAlreadyAssigned)
                {
                    throw new InstructorAlreadyAssignedAtThatTimePeriodException();
                }

                var entity = new Reservation
                {
                    dateDebut = request.dateDebut,
                    dateFin = request.dateFin,
                    instructorId = request.instructorId,
                    salleId = request.salleId,
                    coursId = request.coursId
                };

                repository.Reservation.Create(entity);
                await repository.SaveAsync();

                return Unit.Value; //this represents a void type , i'll need to return a reservation object later ; so this is temporary
            }
        }
    }
}
