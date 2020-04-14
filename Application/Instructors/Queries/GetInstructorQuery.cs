using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Application.Common.Exceptions;
using System.Linq;
using Application.Salles.DTO;
using Application.Instructors.DTO;

namespace Application.Instructors.Queries
{
    public class GetInstructorQuery : IRequest<InstructorDto>
    {
        public Guid Id { get; set; }

        public class GetInstructorQueryHandler : IRequestHandler<GetInstructorQuery, InstructorDto>
        {
            private readonly IRepositoryWrapper repository;

            public GetInstructorQueryHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<InstructorDto> Handle(GetInstructorQuery request, CancellationToken cancellationToken)
            {
                var entity= await repository.Instructor.GetInstructorAsync(request.Id);
                if (entity == null)
                {
                    throw new EntityNotFoundException();
                }
                return entity;
            }
        }
    }
}
