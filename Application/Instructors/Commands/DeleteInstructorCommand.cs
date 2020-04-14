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

namespace Application.Instructors.Commands
{
    public class DeleteInstructorCommand : IRequest
    {
        public Guid Id { get; set; }



        public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand>
        {
            private readonly IRepositoryWrapper repository;

            public DeleteInstructorCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
            {
                var entity=await repository.Instructor.FindByCondition(s => s.Id.Equals(request.Id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }

                    repository.Instructor.Delete(entity);
                    await repository.SaveAsync();
                    return Unit.Value;
            }
        }
    }
}
