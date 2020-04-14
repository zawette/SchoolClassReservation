using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SchoolClassReservationDbContext _repositoryContext;
        private readonly IMapper _mapper;

        public RepositoryWrapper(SchoolClassReservationDbContext repositoryContext, IMapper mapper)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;

        }
        public ICoursRepository Cours => new CoursRepository(_repositoryContext,_mapper);

        public IInstructorRepository Instructor => new InstructorRepository(_repositoryContext, _mapper);

        public ISalleRepository Salle => new SalleRepository(_repositoryContext, _mapper);

        public IReservationRepository Reservation => new ReservationRepository(_repositoryContext, _mapper);

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
