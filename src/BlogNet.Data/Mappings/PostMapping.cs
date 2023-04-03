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

        //public int Curtidas { get; set; }
        builder.Property(x => x.Curtidas)
            .IsRequired(false);
    }
}
