using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Instructors.Commands
{
    public class CreateInstructorCommand : IRequest
    {
        public string nom { get; set; }



        public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand>
        {
            private readonly IRepositoryWrapper repository;

            public CreateInstructorCommandHandler(IRepositoryWrapper Repo)
            {
                repository = Repo;
            }

            public async Task<Unit> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
            {
                var entity = new Instructor
                {
                    nom = request.nom,

                };
                repository.Instructor.Create(entity);
                await repository.SaveAsync();

                return Unit.Value; //this represents a void type , i'll need to return a reservation object later ; so this is temporary
            }
        }
    }
}
