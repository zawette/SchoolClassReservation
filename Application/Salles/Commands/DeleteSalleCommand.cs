using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.Salles.Commands
{
    public class DeleteSalleCommand : IRequest
    {
        public Guid Id { get; set; }



        public class DeleteSalleCommandHandler : IRequestHandler<DeleteSalleCommand>
        {
            private readonly IRepositoryWrapper repository;

            public DeleteSalleCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(DeleteSalleCommand request, CancellationToken cancellationToken)
            {

                var entity=await repository.Salle.FindByCondition(s => s.Id.Equals(request.Id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }

                try
                {
                    repository.Salle.Delete(entity);
                    await repository.SaveAsync();
                    return Unit.Value;
                }
                catch (Exception e)
                {
                    var exception= e.InnerException as SqlException;
                    if (exception.Number == 547) throw new FieldUsedInReservationException(entity.designation);
                    throw;
                }


            }
        }
    }
}
