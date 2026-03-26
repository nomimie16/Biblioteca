using Moq;

public class CatalogManagerTest
{
    private readonly Mock<IGenericRepository<Book>> _mockBooks;
    private readonly ICatalogManager  _catalogManager;
    private readonly List<Book> _books;

    public CatalogManagerTest()
    {
        //create fake repository common for each test
        _mockBooks = new Mock<IGenericRepository<Book>>();

        //create list of books
        _books = new List<Book>
        {
            new Book { Id = 1, Name = "Livre 1", Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Livre 2", Type = TypeBook.Poètique },
            new Book { Id = 3, Name = "Livre 3", Type = TypeBook.Policier },
        };

        //create catalog
        _catalogManager = new CatalogManager(_mockBooks.Object);

    }

    [Fact]
    public void GetAllCatalog_ReturnsAllBooks()
    {
        // Arrange : dire au mock quoi retourner quand getmult. est appelé
        _mockBooks
            .Setup(r => r.GetMultiple(null))
            .Returns(_books);

        // Act : Exécute la méthode à tester
        var result = _catalogManager.GetCatalog();

        // Assert : Vérifie le résultat (3livres)
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void GetCatalog_WithType_ReturnsFilteredBooks()
    {
        // Arrange : dire au mock quoi retourner quand getmult. est appelé
        _mockBooks
            .Setup(r => r.GetMultiple(It.IsAny<Func<Book, bool>>()))
            .Returns(_books.Where(b => b.Type == TypeBook.Aventure).ToList());

        // Act : Exécute la méthode à tester
        var result = _catalogManager.GetCatalog(TypeBook.Aventure);

        // Assert : Vérifie le résultat (1livre)
        Assert.Equal(1, result.Count());
    }

    [Fact]
    public void FindBook_ReturnsOneFilteredBooks()
    {
        // Arrange : dire au mock quoi retourner quand getmult. est appelé
        _mockBooks
            .Setup(r => r.GetMultiple(It.IsAny<Func<Book, bool>>()))
            .Returns(new List<Book> { _books[0] }); //retourne le livre Id=1

        // Act : Exécute la méthode à tester
        var result = _catalogManager.FindBook(1);

        // Assert : Vérifie le résultat (1livre)
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void FindBook_WithInvalidId_ReturnsNull()
    {
        // Arrange : dire au mock quoi retourner quand getmult. est appelé
        _mockBooks
            .Setup(r => r.GetMultiple(It.IsAny<Func<Book, bool>>()))
            .Returns(new List<Book>()); //censé retourner liste vide

        // Act : Exécute la méthode à tester (-1 car id négatif impossible en sql)
        var result = _catalogManager.FindBook(-1);

        // Assert : Vérifie le résultat (1livre)
        Assert.Null(result);
    }
}