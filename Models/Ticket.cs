using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2MuseumVersion2.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Ім`я покупця")]
        public string Name { get; set; } = null!;
        public int ExhibitionId { get; set; }
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
        public virtual Worker Worker { get; set; } = null!;
        public virtual Exhibition Exhibition { get; set; } = null!;
    }
}
