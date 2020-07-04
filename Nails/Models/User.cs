using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nails.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Фото")]
        public string Photo { get; set; }
        [DisplayName("Регион")]
        public Region Region { get; set; }
        [DisplayName("Город")]
        public City City { get; set; }
        [DisplayName("Контакты")]
        public ICollection<Contact> Contacts { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
