using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name="Movie")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [Display(Name="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:D}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:D}")]
        public DateTime DateAdded { get; set; }

        [Display(Name="Quantity in Stock")]
        public int NumberInStock { get; set; }
    }
}