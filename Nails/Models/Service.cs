using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nails.Models
{
    public class Service
    {
        public int Id { get; set; }
        [DisplayName("Наименование")]
        public string Title { get; set; }
        [DisplayName("Категория")]
        public string Category { get; set; }
        [DisplayName("Стоимость")]
        [DisplayFormat(DataFormatString = "{0:c0}")]
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
