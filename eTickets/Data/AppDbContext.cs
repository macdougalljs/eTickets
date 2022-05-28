﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });  // combination of primary keys

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);  // movie side

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);  // actor side


            base.OnModelCreating(modelBuilder);   // needed for when we define the default authentication tables
        }

        public DbSet<Actor> Actors
        {
            get; set;
        }

        public DbSet<Movie> Movies
        {
            get; set;
        }
        public DbSet<Actor_Movie> Actors_Movies
        {
            get; set;
        }
        public DbSet<Cinema> Cinemas
        {
            get; set;
        }

        public DbSet<Producer> Producers
        {
            get; set;
        }
    }
}