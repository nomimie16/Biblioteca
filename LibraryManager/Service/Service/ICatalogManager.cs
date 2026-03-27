public interface ICatalogManager
{
    Book FindBook(int id);
    IEnumerable<Book> GetCatalog();
    IEnumerable<Book> GetCatalog(TypeBook type);
    Book AddBook(Book book);
    void DeleteBook(int id);
    Book GetTopRated();
}