using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using System.Linq;
using Application.Salles.DTO;

namespace Application.Salles.Queries
{
    public class GetSalleQuery : IRequest<SalleDto>
    {
        public Guid Id { get; set; }

        public class GetSalleQueryHandler : IRequestHandler<GetSalleQuery,SalleDto>
        {
            private readonly IRepositoryWrapper repository;

            public GetSalleQueryHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<SalleDto> Handle(GetSalleQuery request, CancellationToken cancellationToken)
            {
                var entity= await repository.Salle.GetSalleAsync(request.Id);
                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                return entity;
            }
        }
    }
}
