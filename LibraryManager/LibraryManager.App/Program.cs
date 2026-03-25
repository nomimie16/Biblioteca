public class Program
{
    static void Main(string[] args)
    {
        // Creation de liste de livres
        List<Book> books = new List<Book>
        {
            new Book { Name = "Alice au pays des merveilles", Type = "Aventure" },
            new Book { Name = "Hunger Games", Type = "Science fiction" },
            new Book { Name = "Romeo et Juliette", Type = "Romance" },

        };

        // Boucle pour afficher les livres et leur type
        Console.WriteLine("Liste des livres : ");
        foreach (var book in books)
        {
            Console.WriteLine(book.Name +" : "+ book.Type);
        }

        // Filtre les livres de type aventure et affiche
        var categoryAbooks = books.Where(book => book.Type == "Aventure");
        foreach (var book in categoryAbooks)
        {
            Console.WriteLine($"Livre de type aventure : {book.Name}");
        }

       

    }
}