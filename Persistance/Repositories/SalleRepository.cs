using Application.Common.Interfaces;
using Application.Salles.DTO;
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
    public class SalleRepository : RepositoryBase<Salle>, ISalleRepository
    {
        private readonly SchoolClassReservationDbContext _repositoryContext;
        private readonly IMapper _mapper;

        public SalleRepository(SchoolClassReservationDbContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalleDto>> GetSallesAsync()
        {   
            return await FindAll().Select(c => _mapper.Map<SalleDto>(c)).ToListAsync();
        }

        public async Task<SalleDto> GetSalleAsync(Guid Id)
        {
            var salle=await FindByCondition(s => s.Id.Equals(Id)).FirstOrDefaultAsync();
            return _mapper.Map<SalleDto>(salle);
        }

    }
}
