using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2MuseumVersion2.Models
{
    public class Worker
    {
        public Worker()
        {
            Tickets = new List<Ticket>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Ім`я")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Зарплата")]
        public string Salary { get; set; } = null!;
        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
