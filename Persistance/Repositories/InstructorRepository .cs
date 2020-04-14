using Application.Common.Interfaces;
using Application.Instructors.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class InstructorRepository : RepositoryBase<Instructor>, IInstructorRepository
    {
        private readonly SchoolClassReservationDbContext _repositoryContext;
        private readonly IMapper _mapper;

        public InstructorRepository(SchoolClassReservationDbContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;

        }

        public async Task<IEnumerable<InstructorDto>> GetInstructorsAsync()
        {
            return await FindAll().Select(c => _mapper.Map<InstructorDto>(c)).ToListAsync();
        }

        public async Task<InstructorDto> GetInstructorAsync(Guid Id)
        {
            var instructor = await FindByCondition(s => s.Id.Equals(Id)).FirstOrDefaultAsync();
            return _mapper.Map<InstructorDto>(instructor);
        }

    }
}
