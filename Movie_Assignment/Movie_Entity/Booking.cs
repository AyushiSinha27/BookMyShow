using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Movie_Entity
{
   public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string status { get; set; }
        public string seat { get; set; }

        [ForeignKey("ShowTiming")]
        public int ShowId { get; set; }
        public Showtiming Showtiming { get; set; }

        [ForeignKey("User")]
        public int uid { get; set; }
        public User User { get; set; }
    }
}
