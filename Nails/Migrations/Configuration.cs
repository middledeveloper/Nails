
namespace Nails.Migrations
{
    using Nails.EntityConfigurations;
    using Nails.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NailsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NailsContext context)
        {
            var dt = DateTime.Now;

            var region = new Region() { Id = 1, Title = "������������� �������", Created = dt, Updated = dt };

            context.Regions.AddOrUpdate(region);

            var city = new City() { Id = 1, Title = "��������", Region = region, Created = dt, Updated = dt };

            context.Cities.AddOrUpdate(city);

            var master = new Master()
            {
                Id = 1,
                FirstName = "����",
                LastName = "����������",
                Photo = "/Content/Photos/Users/yulya.jpg",
                ExperienceYears = 1,
                Region = region,
                City = city,
                Created = dt,
                Updated = dt
            };

            var contactType1 = new ContactType() { Id = 1, Title = "Email", Logo = "/Content/Logos/Email.png", Created = dt, Updated = dt };
            var contactType2 = new ContactType() { Id = 2, Title = "Instagram", Logo = "/Content/Logos/Instagram.png", Created = dt, Updated = dt };
            var contactType3 = new ContactType() { Id = 3, Title = "Whatsapp", Logo = "/Content/Logos/Whatsapp.png", Created = dt, Updated = dt };
            var contactType4 = new ContactType() { Id = 4, Title = "���������", Logo = "/Content/Logos/VK.png", Created = dt, Updated = dt };

            context.ContactTypes.AddOrUpdate(contactType1);
            context.ContactTypes.AddOrUpdate(contactType2);
            context.ContactTypes.AddOrUpdate(contactType3);
            context.ContactTypes.AddOrUpdate(contactType4);

            var contact2 = new Contact() { Id = 1, ContactType = contactType2, Address = "https://www.instagram.com/afanaseva_nail/", User = master, Created = dt, Updated = dt };
            var contact3 = new Contact() { Id = 2, ContactType = contactType3, Address = "https://wa.me/79633431516", User = master, Created = dt, Updated = dt };
            var contact4 = new Contact() { Id = 3, ContactType = contactType4, Address = "https://vk.com/yuliya_afanaseva", User = master, Created = dt, Updated = dt };

            context.Contacts.AddOrUpdate(contact2);
            context.Contacts.AddOrUpdate(contact3);
            context.Contacts.AddOrUpdate(contact4);

            context.Masters.AddOrUpdate(master);

            var certificationAuthority1 = new CertificationAhority() { Id = 1, Title = "Paris Nail", Url = "https://parisnail.ru/", Created = dt, Updated = dt };
            var certificationAuthority2 = new CertificationAhority() { Id = 2, Title = "Kart Effective", Url = "https://academyexpert.ru/", Created = dt, Updated = dt };

            context.CertificationAhorities.AddOrUpdate(certificationAuthority1);
            context.CertificationAhorities.AddOrUpdate(certificationAuthority2);

            var cert1 = new Certificate() { Id = 1, Authority = certificationAuthority1, Scan = "/Content/Certificates/cert1.jpg", Master = master, Created = dt, Updated = dt };
            var cert2 = new Certificate() { Id = 2, Authority = certificationAuthority1, Scan = "/Content/Certificates/cert2.jpg", Master = master, Created = dt, Updated = dt };
            var cert3 = new Certificate() { Id = 3, Authority = certificationAuthority1, Scan = "/Content/Certificates/cert3.jpg", Master = master, Created = dt, Updated = dt };
            var cert4 = new Certificate() { Id = 4, Authority = certificationAuthority2, Scan = "/Content/Certificates/cert4.jpg", Master = master, Created = dt, Updated = dt };

            context.Certificates.AddOrUpdate(cert1);
            context.Certificates.AddOrUpdate(cert2);
            context.Certificates.AddOrUpdate(cert3);
            context.Certificates.AddOrUpdate(cert4);

            var reject1 = new RejectionReason() { Id = 1, Title = "����� �������", Created = dt, Updated = dt };
            var reject2 = new RejectionReason() { Id = 2, Title = "����� �������", Created = dt, Updated = dt };
            var reject3 = new RejectionReason() { Id = 3, Title = "������ �������", Created = dt, Updated = dt };

            context.RejectionReasons.AddOrUpdate(reject1);
            context.RejectionReasons.AddOrUpdate(reject2);
            context.RejectionReasons.AddOrUpdate(reject3);

            context.Photos.AddOrUpdate(new Photo() { Id = 1, Path = "/Content/Photos/Manicure/manicure1.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 2, Path = "/Content/Photos/Manicure/manicure2.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 3, Path = "/Content/Photos/Manicure/manicure3.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 4, Path = "/Content/Photos/Manicure/manicure4.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 5, Path = "/Content/Photos/Manicure/manicure5.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 6, Path = "/Content/Photos/Manicure/manicure6.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 7, Path = "/Content/Photos/Manicure/manicure7.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 8, Path = "/Content/Photos/Manicure/manicure8.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 9, Path = "/Content/Photos/Manicure/manicure9.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 10, Path = "/Content/Photos/Manicure/manicure10.jpg" });
            context.Photos.AddOrUpdate(new Photo() { Id = 11, Path = "/Content/Photos/Manicure/manicure11.jpg" });

            context.ContentBlocks.AddOrUpdate(new ContentBlock()
            {
                Id = 1,
                Title = "������� � ��������",
                HtmlId = "manicure",
                Content =
                    "�������� ������� � ��������. ������������ �� ����� � ����� �� ��������� - ���������." +
                    "������� ������� ����� ����� �������, ������� ������� �������� �������� � ������ �� �������. " +
                    "���������� �����������, �������� ����������� ������ - �������� ������������ � ���������� ��������. ",
                Created = dt,
                Updated = dt
            });

            context.ContentBlocks.AddOrUpdate(new ContentBlock()
            {
                Id = 2,
                Title = "������� � ��������",
                HtmlId = "pedicure",
                Content =
                    "�������� ������� � ��������. ������� - ��� ���������� �������������� � ���� �� ����� ���� � �������. " +
                    "�������, ������ � �������� ����� ���������� �� ������ ����������, �� � ����������� ����! " +
                    "������� ��������� ������������ ���� �� ����� � �������, ������� ��������� ������� � ����������� � ����.",
                Created = dt,
                Updated = dt
            });
        }
    }
}