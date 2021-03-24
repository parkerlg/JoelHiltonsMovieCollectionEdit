using System;
using System.Collections.Generic;

namespace JoelHiltonsMovieCollectionEdit.Models
{
    public static class TempStorage
    {
        private static List<Movies> movies = new List<Movies>();

        public static IEnumerable<Movies> Movies => movies;

        public static void AddMovie(Movies movie)
        {
            movies.Add(movie);
        }
    }
}