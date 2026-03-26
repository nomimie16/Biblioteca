public interface ICatalogManager
{
    Book FindBook(int id);
    IEnumerable<Book> GetCatalog();
    IEnumerable<Book> GetCatalog(TypeBook type);
}