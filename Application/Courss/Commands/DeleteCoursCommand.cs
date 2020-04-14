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

namespace Application.Courss.Commands
{
    public class DeleteCoursCommand : IRequest
    {
        public Guid Id { get; set; }



        public class DeleteCoursCommandHandler : IRequestHandler<DeleteCoursCommand>
        {
            private readonly IRepositoryWrapper repository;

            public DeleteCoursCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(DeleteCoursCommand request, CancellationToken cancellationToken)
            {
                var entity=await repository.Cours.FindByCondition(s => s.Id.Equals(request.Id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }

                    repository.Cours.Delete(entity);
                    await repository.SaveAsync();
                    return Unit.Value;
            }
        }
    }
}
