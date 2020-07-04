using System;

namespace Nails.Models
{
    public class Testimonial
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Client Client { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}