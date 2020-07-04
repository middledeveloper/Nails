using System.Collections.Generic;
using System.ComponentModel;

namespace Nails.Models
{
    public class Master : User
    {
        [DisplayName("Сертификаты")]
        public ICollection<Certificate> Certificates { get; set; }
        [DisplayName("Практический опыт")]
        public int ExperienceYears { get; set; }
    }
}
