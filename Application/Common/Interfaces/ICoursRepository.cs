using Application.Courss.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICoursRepository:IRepositoryBase<Cours>
    {
        public Task<IEnumerable<CoursDto>> GetCoursAsync();
        public Task<CoursDto> GetSingleCoursAsync(Guid Id);

    }
}
