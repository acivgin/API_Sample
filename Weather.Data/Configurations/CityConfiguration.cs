using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Weather.Core.Entities.Location;

namespace Weather.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.OpenWeatherCityId).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.CountryCode).IsRequired();

            builder.ToTable("Cities");
        }
    }
}
