using System;
using System.Collections.Generic;

namespace Nails.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Master Master { get; set; }
        public ICollection<Service> ServiceList { get; set; }
        public City City { get; set; }
        public DateTime ReceptionTime { get; set; }
        public bool Completed { get; set; }
        public RejectionReason RejectionReason { get; set; }
        public Testimonial Feedback { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
