﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MoviesDto
    {
        #region Properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; } 
        #endregion
    }
}