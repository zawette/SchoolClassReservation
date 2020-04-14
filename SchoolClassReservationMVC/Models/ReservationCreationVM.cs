using Application.Courss.DTO;
using Application.Instructors.DTO;
using Application.Salles.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolClassReservationMVC.Models
{
    public class ReservationCreationVM
    {
        public List<InstructorDto> Instructors { get; set; }
        public List<CoursDto> Cours { get; set; }
        public List<SalleDto> Salles { get; set; }
        public Guid instructorId { get; set; }
        public Guid salleId { get; set; }
        public Guid coursId { get; set; }

        public DateTime dateDebut { get; set; } = DateTime.Now;
        public DateTime dateFin { get; set; } = DateTime.Now.AddHours(2);

        public ReservationCreationVM()
        {
            Instructors = new List<InstructorDto>();
            Cours = new List<CoursDto>();
            Salles = new List<SalleDto>();
        }

        public static async Task<ReservationCreationVM> getFromApiAsync()
        {
            var reservationCreationVM = new ReservationCreationVM();
            using var httpClient = new HttpClient();
            using var InstructorsResponse = await httpClient.GetAsync("https://localhost:44336/api/Instructors");
            using var CoursResponse = await httpClient.GetAsync("https://localhost:44336/api/Cours");
            using var SallesResponse = await httpClient.GetAsync("https://localhost:44336/api/Salles");
            string apiResponse = await InstructorsResponse.Content.ReadAsStringAsync();
            reservationCreationVM.Instructors = JsonConvert.DeserializeObject<List<InstructorDto>>(apiResponse);
            apiResponse = await CoursResponse.Content.ReadAsStringAsync();
            reservationCreationVM.Cours = JsonConvert.DeserializeObject<List<CoursDto>>(apiResponse);
            apiResponse = await SallesResponse.Content.ReadAsStringAsync();
            reservationCreationVM.Salles = JsonConvert.DeserializeObject<List<SalleDto>>(apiResponse);
            return reservationCreationVM;
        }

    }
}
