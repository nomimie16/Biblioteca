public class Library : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public IEnumerable<Book> Books { get; set; }
}