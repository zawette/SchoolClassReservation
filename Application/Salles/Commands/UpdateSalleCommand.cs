using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.Salles.Commands
{
    public class UpdateSalleCommand : IRequest
    {
        public string designation { get; set; }
        public Guid Id { get; set; }


        public class UpdateSalleCommandHandler : IRequestHandler<UpdateSalleCommand>
        {
            private readonly IRepositoryWrapper repository;

            public UpdateSalleCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(UpdateSalleCommand request, CancellationToken cancellationToken)
            {
                var entity = await repository.Salle.FindByCondition(s => s.Id.Equals(request.Id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                try
                {
                    entity.designation = request.designation;
                    repository.Salle.Update(entity);
                    await repository.SaveAsync();
                    return Unit.Value; 
                }
                catch (Exception e)
                {
                    var exception = e.InnerException as SqlException;
                    if (exception.Number == 2601) throw new DupplicateUniqueFieldException(request.designation);
                    throw;
                }

            }
        }
    }
}
