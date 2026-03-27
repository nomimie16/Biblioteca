public class CatalogManager : ICatalogManager
{
    private readonly IGenericRepository<Book> _bookRepository;

    public CatalogManager(IGenericRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public IEnumerable<Book> GetCatalog()
    {
        return _bookRepository.GetMultiple();
    }
    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _bookRepository.GetMultiple(filter : b => b.Type == type);
    }
    public Book FindBook(int id)
    {
        return _bookRepository.GetMultiple(filter: b => b.Id == id).FirstOrDefault();
    }
    public Book AddBook(Book book)
    {
        return _bookRepository.Add(book);
    }
    public void DeleteBook (int id)
    {
        _bookRepository.Delete(id);
    }
    public Book GetTopRated()
    {
        return _bookRepository.GetMultiple().MaxBy(b => b.Rate);
    }

}