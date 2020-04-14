using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using System.Linq;
using Application.Courss.DTO;

namespace Application.Courss.Queries
{
    public class GetCoursQuery : IRequest<CoursDto>
    {
        public Guid Id { get; set; }

        public class GetCoursQueryHandler : IRequestHandler<GetCoursQuery, CoursDto>
        {
            private readonly IRepositoryWrapper repository;

            public GetCoursQueryHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<CoursDto> Handle(GetCoursQuery request, CancellationToken cancellationToken)
            {
                var entity= await repository.Cours.GetSingleCoursAsync(request.Id);
                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                return entity;
            }
        }
    }
}
