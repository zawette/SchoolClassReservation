using Application.Common.Interfaces;
using Application.Instructors.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Instructors.Queries
{
    public class GetAllInstructorsQuery : IRequest<IEnumerable<InstructorDto>>
    {
        public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, IEnumerable<InstructorDto>>
        {
            private readonly IRepositoryWrapper repository;

            public GetAllInstructorsQueryHandler(IRepositoryWrapper repo)
            {
                repository = repo;
            }


            public async Task<IEnumerable<InstructorDto>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
            {
                return await repository.Instructor.GetInstructorsAsync();
            }
        }
    }
}
