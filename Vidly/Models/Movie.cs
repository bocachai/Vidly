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

        [Required]
        [Display(Name="Movie")]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Display(Name="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:D}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:D}")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Quantity in Stock")]
        [Range (1, 20)]
        public int NumberInStock { get; set; }
    }
}