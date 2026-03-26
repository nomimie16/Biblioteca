
using Microsoft.EntityFrameworkCore;
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    // DbSet : Représente une table de la base de données
    public DbSet<Book> book { get; set; }

    public DbSet<Library> library  { get; set; }

    public DbSet<Author> author { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des relations Many-to-Many
        modelBuilder.Entity<Library>()
            .HasMany(b => b.Books)
            .WithMany(l => l.Libraries)
            .UsingEntity(j => j.ToTable("libraries"));

        // Configuration des relations One-to-Many
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.Id_author);
    }
}

