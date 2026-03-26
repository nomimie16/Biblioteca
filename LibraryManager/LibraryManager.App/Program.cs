using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public class Program
{
    private static IHost CreateHostBuilder(List <Book> books)
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<List<Book>>(books);
                services.AddTransient<IGenericRepository<Book>, BookRepository>();
                // Enregistrement des services
                services.AddTransient<ICatalogManager, CatalogManager>();
            })
            .Build();
    }

    static void Main(string[] args)
    {
        List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Titre 1", Type = TypeBook.Policier },
            new Book { Id = 2, Name = "Titre 2", Type = TypeBook.Aventure },
            new Book { Id = 3, Name = "Titre 3", Type = TypeBook.Poètique },
            new Book { Id = 4, Name = "Titre 4", Type = TypeBook.Jeunesse },
            new Book { Id = 5, Name = "Titre 5", Type = TypeBook.Aventure },
        };

        var host = CreateHostBuilder(books);
        using var serviceScope = host.Services.CreateScope();
        var services = serviceScope.ServiceProvider;
        // Récupération du service configuré
        ICatalogManager catalogManager = services.GetRequiredService<ICatalogManager>();

        //use the service
        var allCatalog = catalogManager.GetCatalog();
        var filterredBook = catalogManager.GetCatalog(TypeBook.Aventure);
        var bookFound = catalogManager.FindBook(1);

        //display
        Console.WriteLine("All items: ");
        foreach (var book in filterredBook)
        {
            Console.WriteLine($"- {book.Name}");
        }
        Console.WriteLine($"Book found : {bookFound?.Name}");
    }
}