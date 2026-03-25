public class LibraryRepository
{
    private List<Library> _libraries;

    public IEnumerable<Library> GetAll()
    {
        return _libraries;
    }

    public Library Get(int id)
    {
        return _libraries.FirstOrDefault(l => l.Id == id);
    }
}