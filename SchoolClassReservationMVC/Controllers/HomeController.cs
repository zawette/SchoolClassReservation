using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Reservations.DTO;
using Application.Salles.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolClassReservationMVC.Models;

namespace SchoolClassReservationMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<ReservationDto> Reservations = new List<ReservationDto>();
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://localhost:44336/api/Reservations");
            string apiResponse = await response.Content.ReadAsStringAsync();
            Reservations = JsonConvert.DeserializeObject<List<ReservationDto>>(apiResponse);
            return View(Reservations);
        }

        public async Task<IActionResult> AddReservation()
        {
            var reservationCreationVM = await ReservationCreationVM.getFromApiAsync();
            if (TempData["apiResponse"]!=null) ViewBag.Error = TempData["apiResponse"].ToString();

            return View(reservationCreationVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(ReservationCreationVM reservation)
        {
            var reservationToSend = new Reservation
            {
                coursId = reservation.coursId,
                salleId = reservation.salleId,
                instructorId = reservation.instructorId,
                dateDebut = reservation.dateDebut,
                dateFin = reservation.dateFin
            };
            using var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(reservationToSend), Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync("https://localhost:44336/api/Reservations", content);
            string apiResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var receivedReservation = new Reservation();
                receivedReservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["apiResponse"] = apiResponse;
                return RedirectToAction("AddReservation");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
