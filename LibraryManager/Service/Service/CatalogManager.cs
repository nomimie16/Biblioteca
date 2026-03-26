public class CatalogManager
{
    private readonly BookRepository _bookRepository;

    public CatalogManager(List <Book> books)
    {
        _bookRepository = new BookRepository(books);
    }
    public IEnumerable<Book> GetCatalog()
    {
        return _bookRepository.GetAll();
    }
    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _bookRepository.GetAll().Where(book => book.Type == type);
    }
    public Book FindBook(int id)
    {
        return _bookRepository.Get(id);
    }
}