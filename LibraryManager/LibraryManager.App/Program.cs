public class Program
{
    static void Main(string[] args)
    {
        // List<T> est une collection générique qui peut contenir plusieurs éléments du type T
        List<Book> Books = new List<Book>
        {
            new Book { Name = "Titre 1", Type = "Aventure" },
            new Book { Name = "Titre 2", Type = "Policier" },
            new Book { Name = "Titre 3", Type = "Policier" },
            new Book { Name = "Titre 4", Type = "Aventure" },
        };

        //afficher les livres
        foreach(Book b in Books)
        {
            Console.WriteLine("Nom du livre {0} - Type du livre {1}", b.Name, b.Type);
        }

        //filtre les livres
        var categoryAventure = Books.Where(Book => Book.Type == "Aventure");
        foreach(Book b in categoryAventure)
        {
            Console.WriteLine("Livres d'aventure : {0}", b.Name);
        }

        
    }
}