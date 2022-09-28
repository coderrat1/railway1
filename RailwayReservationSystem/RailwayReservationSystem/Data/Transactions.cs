using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using RailwayReservationSystem.Models;

namespace RailwayReservationSystem.Data
{
    public class Transactions
    {
        public long TransactionNumber { get; set; }
        public long CardNumber { get; set; }
        public int ExpiryYear { get; set; }
        public int ExpiryMonth { get; set; }
        public int CVV { get; set; }
        public string CardHolderName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public long GenerateTransactionNumber()
        {
            return TransactionNumber;
        }
    }
}