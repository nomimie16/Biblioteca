public class LibraryRepository
{
    //"_" stand for intern variable
    private List<Library> _libraries;

    //to receive the list
    public LibraryRepository(List<Library> libraries)
    {
        _libraries = libraries;
    }

    //get all the Library
    public IEnumerable<Library> GetAll()
    {
        return _libraries;
    }

    //search on Library's id and return the Library
    public Library Get(int id)
    {
        return _libraries.FirstOrDefault(a => a.Id == id);
    }
}