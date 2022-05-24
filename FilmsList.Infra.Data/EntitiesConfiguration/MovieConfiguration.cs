using FilmsList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmsList.Infra.Data.EntitiesConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(movie => movie.Id);
            builder.Property(movie => movie.ImdbId).HasMaxLength(20).IsRequired();
            builder.Property(movie => movie.Score).HasMaxLength(3).IsRequired();
        }
    }
}