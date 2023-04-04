using BlogNet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNet.Data.Context;

public class AppBlogContext : DbContext
{
    public AppBlogContext(DbContextOptions<AppBlogContext> options) : base(options)
    { }

    public DbSet<PostModel> Posts { get; set; }
    public DbSet<CurtidaModel> Curtidas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppBlogContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
