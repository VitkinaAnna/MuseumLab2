using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab2MuseumVersion2.Models
{
    public class Hall
    {
        public Hall()
        {
            Dinosaurs = new List<Dinosaur>();
            Workers = new List<Worker>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинне бути порожнім")]
        [Display(Name = "Назва зали")]
        public string Name { get; set; } = null!;
        public virtual ICollection<Dinosaur> Dinosaurs { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
