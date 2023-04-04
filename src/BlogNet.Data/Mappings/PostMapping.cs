using BlogNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogNet.Data.Mappings;
public class PostMapping : IEntityTypeConfiguration<PostModel>
{
    public void Configure(EntityTypeBuilder<PostModel> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(x => x.Id);

        //public required string Imagem { get; set; }
        builder.Property(x => x.Imagem)
            .HasColumnType("varchar(255)")
            .IsRequired();

        //public required string Titulo { get; set; }
        builder.Property(x => x.Titulo)
           .HasColumnType("varchar(30)")
           .IsRequired();

        //public required string Descricao { get; set; }
        builder.Property(x => x.Descricao)
           .HasColumnType("varchar(500)")
           .IsRequired();

        //public required DateTime CriadoEm { get; set; }
        builder.Property(x => x.CriadoEm)
            .HasColumnType("datetime")
            .IsRequired();

        //public DateTime? AtualizadoEm { get; set; }
        builder.Property(x => x.AtualizadoEm)
            .HasColumnType("datetime")
            .IsRequired(false);

        //public Guid UserId { get; set; }
        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasMany(x => x.Curtidas)
            .WithOne(x => x.PostModel)
            .HasForeignKey(x => x.PostId);
    }
}
