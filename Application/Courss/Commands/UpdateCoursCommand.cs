using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.Courss.Commands
{
    public class UpdateCoursCommand : IRequest
    {
        public string designation { get; set; }
        public Guid Id { get; set; }


        public class UpdateCoursCommandHandler : IRequestHandler<UpdateCoursCommand>
        {
            private readonly IRepositoryWrapper repository;

            public UpdateCoursCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(UpdateCoursCommand request, CancellationToken cancellationToken)
            {
                var entity = await repository.Cours.FindByCondition(s => s.Id.Equals(request.Id)).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }

                entity.designation = request.designation;
                repository.Cours.Update(entity);
                await repository.SaveAsync();
                return Unit.Value;

            }
        }
    }
}
