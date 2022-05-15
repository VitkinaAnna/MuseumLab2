using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2MuseumVersion2.Models
{
    public class Exhibition
    {
        public Exhibition()
        {
            Tickets = new List<Ticket>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинне бути порожнім")]

        [Display(Name = "Назва екскурсії")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Ціна")]
        public string Price { get; set; } = null!;

        public string Information { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
