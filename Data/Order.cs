using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey("FilmSession_Id")]
        public virtual FilmSession FilmSession { get; set; }
        public int FilmSession_Id { get; set; }
    }
}
