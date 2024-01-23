using System;
using Microsoft.EntityFrameworkCore;
using NextConfPro.Services.EventAPI.Models;

namespace NextConfPro.Services.EventAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Event>().HasData(new Event
			{
				Id = 1,
				Name = "The Best Conference Ever",
				Date = DateTime.Today,
				StartTime = DateTime.Now,
				Location = "Test Location 1",
			});

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = 2,
                Name = "The Second Best Conference Ever",
                Date = DateTime.Today,
                StartTime = DateTime.Now,
                Location = "Test Location 2",
            });
        }
    }
}

