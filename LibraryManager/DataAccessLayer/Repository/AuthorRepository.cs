public class AuthorRepository : IGenericRepository<Author>
{
    //"_" stand for intern variable
    private List<Author> _authors;

    //to receive the list
    public AuthorRepository(List<Author> authors)
    {
        _authors = authors;
    }

    //get all the Author
    public IEnumerable<Author> GetAll()
    {
        return _authors;
    }

    //search on author's id and return the author
    public Author Get(int id)
    {
        return _authors.FirstOrDefault(a => a.Id == id);
    }
}