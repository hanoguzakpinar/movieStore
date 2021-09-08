using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public int DirectorID { get; set; }
        public Director Director { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public bool isActive { get; set; } = true;
    }
}