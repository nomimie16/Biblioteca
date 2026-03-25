
public class CatalogManager
{
    private readonly BookRepository _bookRepository;

    public CatalogManager(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    // return all the books
    public IEnumerable<Book> GetCatalog()
    {
        return _bookRepository.GetAll();
    }

    // return bokks by type filter
    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _bookRepository
            .GetAll()
            .Where(b => b.Type == type);
    }

    // return book by id
    public Book FindBook(int id)
    {
        return _bookRepository.Get(id);
    }
}

