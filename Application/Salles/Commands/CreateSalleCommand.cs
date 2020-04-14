using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using Microsoft.Data.SqlClient;

namespace Application.Salles.Commands
{
    public class CreateSalleCommand : IRequest
    {
        public string designation { get; set; }



        public class CreateSalleCommandHandler : IRequestHandler<CreateSalleCommand>
        {
            private readonly IRepositoryWrapper repository;

            public CreateSalleCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(CreateSalleCommand request, CancellationToken cancellationToken)
            {
                var entity = new Salle
                {
                    designation = request.designation,
                };
                try
                {

                    repository.Salle.Create(entity);
                    await repository.SaveAsync();

                    return Unit.Value; //this represents a void type , i'll need to return a reservation object later ; so this is temporary
                }
                catch (Exception e)
                {
                    var exception = e.InnerException as SqlException;
                    if(exception.Number == 2601) throw new DupplicateUniqueFieldException(request.designation);
                    throw;
                }

            }
        }
    }
}
