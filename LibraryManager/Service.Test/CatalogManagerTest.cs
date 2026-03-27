using Moq;
using Xunit;

public class CatalogManagerTest
{
    private readonly Mock<IGenericRepository<Book>> _mockRepository;
    private readonly CatalogManager _catalogManager;
    private readonly List<Book> _fakeBooks;

    public CatalogManagerTest()
    {
        // 1. Initialisation des données factices
        _fakeBooks = new List<Book>
        {
            new Book { Id = 1, Name = "Alice au pays des merveilles", Pages = 15, Type = TypeBook.Aventure },
            new Book { Id = 2, Name = "Hunger Games", Pages = 2, Type = TypeBook.SF },
            new Book { Id = 3, Name = "Romeo et Juliette", Pages = 10, Type = TypeBook.Romance },
            new Book { Id = 4, Name = "Tom et Jerry", Pages = 5, Type = TypeBook.Aventure }
        };

        // 2. Création du mock (simulacre) pour le repository
        _mockRepository = new Mock<IGenericRepository<Book>>();

        // Configuration par défaut : quand on appelle GetAll(), on retourne notre liste factice
        _mockRepository.Setup(repo => repo.GetMultiple()).Returns(_fakeBooks);

        // 3. Instanciation du CatalogManager avec le faux repository injecté
        _catalogManager = new CatalogManager(_mockRepository.Object);
    }

    [Fact]
    public void GetCatalog_ReturnsAllBooks()
    {
        
        var result = _catalogManager.GetCatalog();

        // assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count());
        _mockRepository.Verify(repo => repo.GetMultiple(), Times.Once); 
    }

    [Fact]
    public void GetCatalog_WithTypeFilter_ReturnsOnlyBooksOfThatType()
    {
        // que les livres de type aventure
        var result = _catalogManager.GetCatalog(TypeBook.Aventure);

        // asset
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); 
        Assert.All(result, book => Assert.Equal(TypeBook.Aventure, book.Type));
        _mockRepository.Verify(repo => repo.GetMultiple(), Times.Once);
    }


}
