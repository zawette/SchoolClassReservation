using Application.Common.Interfaces;
using Application.Courss.DTO;
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
    public class CoursRepository : RepositoryBase<Cours>, ICoursRepository
    {
        private readonly SchoolClassReservationDbContext _repositoryContext;
        private readonly IMapper _mapper;

        public CoursRepository(SchoolClassReservationDbContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CoursDto>> GetCoursAsync()
        {
            return await FindAll().Select(c => _mapper.Map<CoursDto>(c)).ToListAsync();
        }

        public async Task<CoursDto> GetSingleCoursAsync(Guid Id)
        {
            var cours = await FindByCondition(s => s.Id.Equals(Id)).FirstOrDefaultAsync();
            return _mapper.Map<CoursDto>(cours);
        }

    }
}
