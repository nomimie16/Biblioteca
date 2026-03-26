public class BookRepository : IGenericRepository<Book>
{
    //"_" stand for intern variable
    private List<Book> _books;

    //receive the list from the main
    public BookRepository(List<Book> books)
    {
        _books = books;
    }

    //get all the book
    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    //search on book's id and return the book
    public Book Get(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }
}