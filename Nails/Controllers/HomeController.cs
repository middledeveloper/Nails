using Nails.EntityConfigurations;
using Nails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Nails.Controllers
{
    public class HomeController : Controller
    {
        readonly NailsContext ctx;
        readonly int MastersCount;

        public HomeController()
        {
            ctx = new NailsContext();
            MastersCount = ctx.Masters.Count();
        }

        public ActionResult Index()
        {
            if (ctx.Services.Count() == 0)
            {
                var services = ImportServicesCsv();
                ctx.Services.AddRange(services);
                ctx.SaveChanges();
            }

            return View();
        }

        public ActionResult Content()
        {
            var blocks = ctx.ContentBlocks.ToList();

            return PartialView("_Content", blocks);
        }

        public ActionResult Photos()
        {
            var photos = ctx.Photos.ToList();
            var random = new Random();

            var randomPhotos = photos.OrderBy(x => random.Next()).Take(8);

            return PartialView("_Photos", randomPhotos);
        }

        public ActionResult Masters()
        {
            if (MastersCount == 1)
            {
                return new EmptyResult();
            }
            else
            {
                var masters = ctx.Masters.ToList();
                foreach (var master in masters)
                {
                    ctx.Entry(master).Reference(m => m.Region).Load();
                    ctx.Entry(master).Reference(m => m.City).Load();
                }

                return new EmptyResult();
                //return PartialView("_Masters", masters);
            }
        }

        public ActionResult Price()
        {
            var services = ctx.Services.ToList().OrderBy(s => s.Category);

            return PartialView("_Price", services);
        }

        public ActionResult Contacts()
        {
            if (MastersCount == 1)
            {
                var master = ctx.Masters.First();

                ctx.Entry(master).Reference(m => m.Region).Load();
                ctx.Entry(master).Reference(m => m.City).Load();
                ctx.Entry(master).Collection(m => m.Certificates).Load();
                ctx.Entry(master).Collection(m => m.Contacts).Load();

                foreach (var certificate in master.Certificates)
                    ctx.Entry(certificate).Reference(c => c.Authority).Load();

                foreach (var contact in master.Contacts)
                    ctx.Entry(contact).Reference(c => c.ContactType).Load();

                return PartialView("_Master", master);
            }
            else
            {
                //return PartialView("_GlobalContacts");
                return new EmptyResult();
            }
        }

        private static List<Service> ImportServicesCsv()
        {
            var path = HostingEnvironment.MapPath("~/Content/Price/Price.csv");

            var csv = System.IO.File.ReadAllLines(path);
            var services = new List<Service>();
            foreach (string csvrow in csv)
            {
                var fields = csvrow.Split(';');
                var service = new Service()
                {
                    Category = fields[0],
                    Title = fields[1],
                    Price = Convert.ToDecimal(fields[2]),
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                };
                services.Add(service);
            }

            return services;
        }
    }
}