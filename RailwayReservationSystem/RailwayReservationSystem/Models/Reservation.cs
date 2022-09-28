using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayReservationSystem.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int TrainId { get; set; }
        public int UserId { get; set; }
        public int PassengerId { get; set; }
        public int PnrNumber { get; set; }
        public string Status { get; set; }
        public decimal TotalFare { get; set; }
        public long TransactionNumber { get; set; }
        public DateTime BookingDate { get; set; }

        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }


        [ForeignKey("TrainId")]
        public virtual Train Train { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}