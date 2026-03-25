
public class AuthorRepository
{

    private List<Author> _authors;

    public IEnumerable<Author> GetAll()
    {
        return _authors;
    }

    public Author Get(int id)
    {
        return _authors.FirstOrDefault(l => l.Id == id);
    }

   
}
