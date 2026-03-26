public class LibraryRepository : IGenericRepository<Library>
{
    //"_" stand for intern variable
    private readonly LibraryContext _context;

    //to receive the list
    public LibraryRepository(LibraryContext context)
    {
        _context = context;
    }

    //get all the Library
    public IEnumerable<Library> GetAll()
    {
        return _context.library.ToList();
    }

    //search on Library's id and return the Library
    public Library Get(int id)
    {
        return _context.library.FirstOrDefault(a => a.Id == id);
    }

    //new method add
    public Library Add(Library entity)
    {
        _context.library.Add(entity);
        _context.SaveChanges();
        return entity;
    }


}