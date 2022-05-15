using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2MuseumVersion2.Models
{
    public class Dinosaur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; } = null!;

        public int HallId { get; set; }

        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Період існування")]
        public string Lifetime { get; set; } = null!;
        [Display(Name = "Назва зали")]

        public virtual Hall Hall { get; set; } = null!;
    }
}
