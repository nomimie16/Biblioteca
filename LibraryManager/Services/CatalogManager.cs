public class CatalogManager : ICatalogManager
{
    private readonly IGenericRepository<Book> _bookRepository;

    public CatalogManager(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    // return all the books
    public IEnumerable<Book> GetCatalog()
    {
        return _bookRepository.GetMultiple();
    }

    // return bokks by type filter
    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _bookRepository
            .GetMultiple()
            .Where(b => b.Type == type);
    }

    // return book by id
    public Book FindBook(int id)
    {
        return _bookRepository.GetMultiple(b => b.Id == id).FirstOrDefault();
    }
}

