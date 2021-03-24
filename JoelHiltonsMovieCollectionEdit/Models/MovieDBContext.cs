using System;
using Microsoft.EntityFrameworkCore;

namespace JoelHiltonsMovieCollectionEdit.Models
    {
        public class MovieDBContext : DbContext
        {
            public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
            {

            }

            public DbSet<Movies> Movies { get; set; }
        }
    }
