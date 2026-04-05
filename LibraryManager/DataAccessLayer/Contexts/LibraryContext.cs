using Microsoft.EntityFrameworkCore;
public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    // DbSet : Représente une table de la base de données
    public DbSet<Book> book { get; set; }
    public DbSet<Author> author { get; set; }
    public DbSet<Library> library { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.Type)
            .HasConversion<string>();

        // One-to-Many (1book a 1 author/1author a pls books)
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.Id_author);

        // Many-to-Many (1book a pls libraries/1library a plus books)
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Libraries)
            .WithMany(l => l.Books)
            .UsingEntity<Dictionary<string, object>>(
                "stock",
                j => j.HasOne<Library>().WithMany().HasForeignKey("id_library"),
                j => j.HasOne<Book>().WithMany().HasForeignKey("id_book")
            );
    }
}