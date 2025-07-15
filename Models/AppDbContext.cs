using Microsoft.EntityFrameworkCore;
using SocialMediaApi.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ContactMessage> ContactMessages { get; set; }
}
