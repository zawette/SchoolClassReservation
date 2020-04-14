using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICoursRepository Cours { get; }
        IInstructorRepository Instructor { get; }
        ISalleRepository Salle { get; }
        IReservationRepository Reservation { get; }
        Task SaveAsync();


    }
}
