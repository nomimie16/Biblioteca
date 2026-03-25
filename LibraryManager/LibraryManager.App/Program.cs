public class Program
{
    static void Main(string[] args)
    {
        /*------------------BOOK TEST------------------*/
        //List<T> est une collection générique qui peut contenir plusieurs éléments du type T
        List<Book> Books = new List<Book>
        {
            new Book { Name = "Titre 1", Type = TypeBook.Policier },
            new Book { Name = "Titre 2", Type = TypeBook.Aventure },
            new Book { Name = "Titre 3", Type = TypeBook.Poètique },
            new Book { Name = "Titre 4", Type = TypeBook.Jeunesse },
        };
        //create BookRepository object and give the books list
        var repoBooks = new BookRepository(Books);
        //display the books
        var allBooks = repoBooks.GetAll();
        foreach(Book b in allBooks)
        {
            Console.WriteLine("Nom du livre {0} - Type du livre {1}", b.Name, b.Type);
        }
        //filter on the books
        var categoryAventure = repoBooks.GetAll().Where(Book => Book.Type == TypeBook.Aventure);
        foreach(Book b in categoryAventure)
        {
            Console.WriteLine("Livre d'aventure : {0}", b.Name);
        }

        /*------------------AUTHOR TEST------------------*/
        //List<T> est une collection générique qui peut contenir plusieurs éléments du type T
        List<Author> Authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "Lilou", LastName = "Châtelain" },
            new Author { Id = 2, FirstName = "Noémie", LastName = "Lignier" },
        };
        //create AuthorRepository object and give the author list
        var repoAuthors = new AuthorRepository(Authors);
        //display the Authors
        var allAuthors = repoAuthors.GetAll();
        foreach (Author a in allAuthors)
        {
            Console.WriteLine("Id {0} - Nom de l'auteur : {1} {2} ", a.Id, a.FirstName, a.LastName);
        }
        //search one author
        var oneAuthor = repoAuthors.Get(1);
        Console.WriteLine("Nom de l'auteur ayant comme id 1 : {0}", oneAuthor.FirstName, oneAuthor.LastName);

        /*------------------LIBRARY TEST------------------*/
        //List<T> est une collection générique qui peut contenir plusieurs éléments du type T
        List<Library> Libraries = new List<Library>
        {
            new Library { Id = 1, Name = "L1" },
            new Library { Id = 2, Name = "L2"},
        };
        //create LibraryRepository object and give the library list
        var repoLibraries = new LibraryRepository(Libraries);
        //display the Libraries
        var allLibraries = repoLibraries.GetAll();
        foreach (Library l in allLibraries)
        {
            Console.WriteLine("Id {0} - Nom de la librairie : {1} ", l.Id, l.Name);
        }
        //search one library
        var oneLibrary = repoLibraries.Get(1);
        Console.WriteLine("Nom de la librairie ayant comme id 1 : {0}", oneLibrary.Name);
    }
}