using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
public class Program
{
    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                // Enregistrement des services
                services.AddTransient<ICatalogManager, CatalogManager>();
                services.AddDbContext<LibraryContext>(options =>
                {
                    // Chemin vers la base de données
                    string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "library.db");
                    options.UseSqlite($"Data Source={dbPath}");
                });
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

        // 1. Créer le host avec la configuration des services
        var host = CreateHostBuilder();

        // 2. Récupérer le service depuis le conteneur DI
        ICatalogManager catalogManager = host.Services.GetRequiredService<ICatalogManager>();

        // 3. Utiliser le service (les dépendances sont automatiquement injectées !)
        var adventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);

        foreach (var book in adventureBooks)
        {
            Console.WriteLine(book.Name);
        }

       

    }
}