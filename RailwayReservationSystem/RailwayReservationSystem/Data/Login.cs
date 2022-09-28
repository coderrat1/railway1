using System;
using System.Collections.Generic;
using System.Text;
using RailwayReservationSystem.Models;

namespace RailwayReservationSystem.Data
{
    public class Login
    {
        public int UserId { get; set; }
        public int Password { get; set; }
        public User User { get; set; }
    }
}