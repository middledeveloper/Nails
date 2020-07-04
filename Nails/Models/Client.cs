using System.Collections.Generic;

namespace Nails.Models
{
    public class Client : User
    {
        public ICollection<Reservation> Reservations { get; set; }
    }
}
