
namespace BuilderTools.Core.Model
{
    public class Reservation
    {
        public Guid ReservationId { get; set; }
        public Guid UserId { get; set; }
        public Guid BuilderToolId{ get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Reservation(Guid reservationId, Guid userId, Guid builderToolId,
            DateTime reservationDate, DateTime startDate, DateTime endDate)
        {
            ReservationId = reservationId;
            UserId = userId;
            BuilderToolId = builderToolId;
            ReservationDate = reservationDate;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
