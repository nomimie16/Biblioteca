
public class BookRepository
{

    private List<Book> _books;

    public BookRepository(List<Book> books)
    {
        _books = books;
    }

    // return all the books
    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    public Book Get(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }
    
}