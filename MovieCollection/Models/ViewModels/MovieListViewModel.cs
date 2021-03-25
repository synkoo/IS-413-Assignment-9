using System;
using System.Collections.Generic;

namespace MovieCollection.Models.ViewModels
{
    public class MovieListViewModel
    {
        public MovieListViewModel()
        {
        }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
