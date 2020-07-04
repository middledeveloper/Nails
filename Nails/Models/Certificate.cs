using System;

namespace Nails.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public Master Master { get; set; }
        public CertificationAhority Authority { get; set; }
        public string Scan { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
