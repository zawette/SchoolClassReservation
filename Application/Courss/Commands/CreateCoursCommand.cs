using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Courss.Commands
{
    public class CreateCoursCommand : IRequest
    {

        public string designation { get; set; }



        public class CreateCoursCommandHandler : IRequestHandler<CreateCoursCommand>
        {
            private readonly IRepositoryWrapper repository;

            public CreateCoursCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(CreateCoursCommand request, CancellationToken cancellationToken)
            {
                var entity = new Cours
                {
                    designation=request.designation
                };

                repository.Cours.Create(entity);
                await repository.SaveAsync();

                return Unit.Value; //this represents a void type , i'll need to return a reservation object later ; so this is temporary
            }
        }
    }
}
