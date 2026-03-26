public class BookRepository : IGenericRepository<Book>
{
    //"_" stand for intern variable
    private readonly LibraryContext _context;

    //receive the list from the main
    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    //get all the book
    public IEnumerable<Book> GetAll()
    {
        return _context.book.ToList();
    }

    //search on book's id and return the book
    public Book Get(int id)
    {
        return _context.book.FirstOrDefault(b => b.Id == id);
    }

    //new method add
    public Book Add(Book entity)
    {
        _context.book.Add(entity);
        _context.SaveChanges();
        return entity;
    }
}