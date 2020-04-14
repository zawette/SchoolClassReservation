using Application.Salles.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISalleRepository : IRepositoryBase<Salle>
    {
        public Task<IEnumerable<SalleDto>> GetSallesAsync();
        public Task<SalleDto> GetSalleAsync(Guid Id);


    }
}
