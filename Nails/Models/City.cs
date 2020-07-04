using System;

namespace Nails.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Region Region { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
