using System;
using System.Collections.Generic;
using System.Text;
using RailwayReservationSystem.Models;

namespace RailwayReservationSystem.Data
{
    public class Register
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public User User { get; set; }
    }
}