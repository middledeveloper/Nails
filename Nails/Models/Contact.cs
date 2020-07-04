using System;

namespace Nails.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ContactType ContactType { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}