using Application.Common.Interfaces;
using Application.Courss.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Courss.Queries
{
    public class GetAllCoursQuery : IRequest<IEnumerable<CoursDto>>
    {
        public class GetAllCoursQueryHandler : IRequestHandler<GetAllCoursQuery, IEnumerable<CoursDto>>
        {
            private readonly IRepositoryWrapper repository;

            public GetAllCoursQueryHandler(IRepositoryWrapper repo)
            {
                repository = repo;
            }


            public async Task<IEnumerable<CoursDto>> Handle(GetAllCoursQuery request, CancellationToken cancellationToken)
            {
              return await repository.Cours.GetCoursAsync();
            }
        }
    }
}
