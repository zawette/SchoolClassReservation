using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.Instructors.Commands
{
    public class UpdateInstructorCommand : IRequest
    {
        public string nom { get; set; }
        public Guid Id { get; set; }


        public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand>
        {
            private readonly IRepositoryWrapper repository;

            public UpdateInstructorCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
            {
                var entity = await repository.Instructor.FindByCondition(s => s.Id.Equals(request.Id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }

                entity.nom = request.nom;
                repository.Instructor.Update(entity);
                await repository.SaveAsync();
                return Unit.Value;

            }
        }
    }
}
