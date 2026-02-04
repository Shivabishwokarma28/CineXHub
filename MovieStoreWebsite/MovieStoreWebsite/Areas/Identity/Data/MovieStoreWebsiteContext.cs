using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebsite.Areas.Identity.Data;
using MovieStoreWebsite.Models;

namespace MovieStoreWebsite.Areas.Identity.Data;

public class MovieStoreWebsiteContext : IdentityDbContext<MovieStoreWebsiteUser>
{
    public MovieStoreWebsiteContext(DbContextOptions<MovieStoreWebsiteContext> options)
        : base(options)
    {
    }
    public DbSet<Movie> MoviesDatabase { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
