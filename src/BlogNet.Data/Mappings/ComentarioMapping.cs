using BlogNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogNet.Data.Mappings;

public class ComentarioMapping : IEntityTypeConfiguration<ComentarioModel>
{
    public void Configure(EntityTypeBuilder<ComentarioModel> builder)
    {
        builder.ToTable("Comentarios");

        builder.HasKey(x => x.Id);

        //public required string Texto { get; set; }
        builder.Property(x => x.Texto)
            .HasColumnType("varchar(500)")
            .IsRequired();

        //public required Guid UserId { get; set; }
        builder.Property(x => x.UserId)
            .IsRequired();

        //public required Guid PostId { get; set; }
        builder.Property(x => x.PostId)
            .IsRequired();

        //public required DateTime CriadoEm { get; set; }
        builder.Property(x => x.CriadoEm)
            .HasColumnType("datetime")
            .IsRequired();

        //public PostModel Post { get; set; }
        builder.HasOne(x => x.Post)
            .WithMany(x => x.Comentarios)
            .HasForeignKey(x => x.PostId);
    }
}
