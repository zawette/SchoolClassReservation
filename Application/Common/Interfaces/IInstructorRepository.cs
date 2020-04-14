using Application.Instructors.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IInstructorRepository : IRepositoryBase<Instructor>
    {
        public Task<IEnumerable<InstructorDto>> GetInstructorsAsync();
        public Task<InstructorDto> GetInstructorAsync(Guid Id);


    }
}
