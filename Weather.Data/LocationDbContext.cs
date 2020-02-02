using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Weather.Core.Entities.Location;
using Weather.Data.Configurations;

namespace Weather.Data
{
    public class LocationDbContext: DbContext
    {
        public DbSet<City> Cities { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=location.db");

        public LocationDbContext(DbContextOptions<LocationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CityConfiguration());
        }
    }
}
