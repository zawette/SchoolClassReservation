using Application.Common.Interfaces;
using Application.Salles.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Salles.Queries
{
    public class GetAllSallesQuery : IRequest<IEnumerable<SalleDto>>
    {
        public class GetAllSallesQueryHandler : IRequestHandler<GetAllSallesQuery, IEnumerable<SalleDto>>
        {
            private readonly IRepositoryWrapper repository;

            public GetAllSallesQueryHandler(IRepositoryWrapper repo)
            {
                repository = repo;
            }


            public async Task<IEnumerable<SalleDto>> Handle(GetAllSallesQuery request, CancellationToken cancellationToken)
            {
                return await repository.Salle.GetSallesAsync();
            }
        }
    }
}
