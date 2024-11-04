using HotelBookingApi.Data;
using HotelBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelDbContext _context;
        public ReservationRepository(HotelDbContext context)
        {
            _context = context;
        }

        async Task IReservationRepository.AddReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        async Task IReservationRepository.DeleteReservationAsync(int id)
        {
            var reservationInDb = await _context.Reservations.FindAsync(id);

            if(reservationInDb == null)
            {
                throw new KeyNotFoundException($"Employee with id {id} was not found.");
            }

            _context.Reservations.Remove(reservationInDb);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<Reservation>> IReservationRepository.GetAllAsync()
        {
         return   await _context.Reservations.ToListAsync();
        }

        async Task<Reservation> IReservationRepository.GetByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        async Task IReservationRepository.UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
