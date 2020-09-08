using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class FilmSession
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название фильма")]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Начало сеанса")]
        public DateTime DateTime { get; set; }
    }
}
