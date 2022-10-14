using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie_Entity
{
    public class Movie
    {

        [Key] //Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MoviesDesc { get; set; }
        public string MovieType { get; set; }
    }
}
