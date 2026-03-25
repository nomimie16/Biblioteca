public class Program
{
    static void Main(string[] args)
    {
        // Creation de liste de livres
        List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Alice au pays des merveilles", Pages = 15, Type = TypeBook.Aventure },
            new Book { Id = 2 , Name = "Hunger Games", Pages = 2, Type = TypeBook.SF,  },
            new Book { Id = 3, Name = "Romeo et Juliette", Type = TypeBook.Romance },
            new Book { Id = 4, Name = "Tom et Jerry", Type = TypeBook.Aventure },

        };

        var repository = new BookRepository(books);
        var foundBook = repository.Get(1);
        var getBooks = repository.GetAll();
        var categoryAbooks = books.Where(book => book.Type == TypeBook.Aventure);

        

        /*Console.WriteLine("Liste des livres : ");
        foreach (var book in repository.GetAll())
        {
            Console.WriteLine(book.Name + " : " + book.Type);
        }*/

        //Console.WriteLine($"\nLivre trouvé (id=1) : {foundBook?.Name}");


        /*foreach (var book in categoryAbooks)
        {
            Console.WriteLine($"Livre de type aventure : {book.Name}");

        }*/

        CatalogManager catalogManager = new CatalogManager(repository);

        var allBooks = catalogManager.GetCatalog(); // recup tout les livres
        var typeBooks = catalogManager.GetCatalog(TypeBook.Aventure); // recup tout les livres d'un type
        var idBook = catalogManager.FindBook(1); // recup les livres avec un id 

       
        Console.WriteLine("---------------------");
        Console.WriteLine("ensemble des livres : ");
        foreach (var book in allBooks)
        {
            Console.WriteLine(book.Name + " : " + book.Type);
        }

        Console.WriteLine("---------------------");
        Console.WriteLine("Livre de type Aventure : ");
        foreach (var book in typeBooks)
        {
            Console.WriteLine(book.Name);
        }

        Console.WriteLine("---------------------");
        Console.WriteLine("Livres avec un id = "+ idBook.Id +" : "+ idBook.Name);

    }
}