public class Program
{
    static void Main(string[] args)
    {
        // List<T> est une collection générique qui peut contenir plusieurs éléments du type T
        List<Book> items = new List<Book>
        {
            new Book { Name = "Alice au pays des merveilles", Type = "Aventure" },
            new Book { Name = "Hunger Games", Type = "Science fiction" },
            new Book { Name = "Romeo et Juliette", Type = "Romance" },

        };

        Console.WriteLine("Liste des livres : ");
        foreach (var item in items)
        {
            Console.WriteLine(item.Name +" : "+ item.Type);
        }
    }
}