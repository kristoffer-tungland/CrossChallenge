using System;
using CrossChallenge.Contracts.Enums;
using Microsoft.EntityFrameworkCore;
using CrossChallenge.Contracts.Models;

namespace CrossChallenge.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Athlete>().HasData(
                new Athlete
                { 
                    AthleteID = 1, Firstname = "Donald", Lastname = "Duck", 
                    Email = "donald@duck.com", Gender = Gender.Male
                });

            modelBuilder.Entity<Activity>().HasData(
                new Activity
                {
                    ActivityID = 1, ActivityType = ActivityType.Hike, Name = "Afternoon walk", 
                    Value = 10.0, Score = 50, AthleteID = 1, StartTime = DateTime.Now, EndTime = DateTime.Now
                });

        }
    }
}