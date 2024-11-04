namespace HotelBookingApi.Models
{
    public class ReservationDTO
    {
        public int id { get; set; }
        public required string RoomNumber { get; set; }
        public required string GuestName { get; set; }
        public required string GuestEmail { get; set; }
        public string? Date { get; set; }
    }
}
