public class AuthorRepository : IGenericRepository<Author>
{
    //"_" stand for intern variable
    private readonly LibraryContext _context;

    //to receive the list
    public AuthorRepository(LibraryContext context)
    {
        _context = context;
    }

    //get all the Author
    public IEnumerable<Author> GetAll()
    {
        return _context.author.ToList();
    }

    //search on author's id and return the author
    public Author Get(int id)
    {
        return _context.author.FirstOrDefault(a => a.Id == id);
    }

    //new method add
    public Author Add(Author entity)
    {
        _context.author.Add(entity);
        _context.SaveChanges();
        return entity;
    }
}