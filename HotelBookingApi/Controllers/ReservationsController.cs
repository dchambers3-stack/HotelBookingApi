using HotelBookingApi.Data;
using HotelBookingApi.Models;
using HotelBookingApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly HotelDbContext _context;
        private readonly IReservationRepository _reservationRepo;
        public ReservationsController(HotelDbContext _dbcontext, IReservationRepository _reservationRepo)
        {
            this._context = _dbcontext;
            this._reservationRepo = _reservationRepo;
        }

       

        [HttpPost]

        public IActionResult AddReservation(ReservationDTO addReservation)
        {
            var newReservation = new Reservation
            {
                id = addReservation.id,
                GuestName = addReservation.GuestName,
                RoomNumber = addReservation.RoomNumber,
                GuestEmail = addReservation.GuestEmail,
                Date = addReservation.Date,


            };
            _context.Add(newReservation);
            _context.SaveChanges();
            return Ok(newReservation);
        }

        [HttpGet]

        public IActionResult GetAllReservations()
        {
            return Ok(_context.Reservations.ToList());

        }

        [HttpGet("{id}")]

         public IActionResult GetById(int id)
        {
            var reservationInDb = _context.Reservations.Find(id);

            return Ok(reservationInDb);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            var currentReservationInDb = _context.Reservations.Find(id);

            if(currentReservationInDb == null)
            {
                return BadRequest();
            }

            _context.Reservations.Remove(currentReservationInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Reservation>> UpdateReservationAsync(int id, Reservation reservation)
        {
            if (id != reservation.id)
            {
                return BadRequest();
            }
            await _reservationRepo.UpdateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetById), new
            {
                id = reservation.id
            }, reservation);
        }

    }
}
