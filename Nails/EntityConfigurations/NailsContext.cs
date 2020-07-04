using Nails.Models;
using System.Data.Entity;

namespace Nails.EntityConfigurations
{
    public class NailsContext : DbContext
    {
        public NailsContext() : base("NailsContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificationAhority> CertificationAhorities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<RejectionReason> RejectionReasons { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}