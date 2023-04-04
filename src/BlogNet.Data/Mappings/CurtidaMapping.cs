using BlogNet.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogNet.Data.Mappings;

public class CurtidaMapping : IEntityTypeConfiguration<CurtidaModel>
{
    public void Configure(EntityTypeBuilder<CurtidaModel> builder)
    {
        builder.ToTable("Curtidas");

        builder.HasKey(x => x.Id);

        //public Guid UserId { get; set; }
        builder.Property(x => x.UserId)
            .IsRequired();

        //public Guid PostagemId { get; set; }
        builder.Property(x => x.PostId)
            .IsRequired();

        //public DateTime CriadoEm { get; set; }
        builder.Property(x => x.CriadoEm)
            .IsRequired();

        //public PostModel? PostModel { get; set; }
        builder.HasOne(x => x.PostModel)
            .WithMany(x => x.Curtidas)
            .HasForeignKey(x => x.PostId);
    }
}