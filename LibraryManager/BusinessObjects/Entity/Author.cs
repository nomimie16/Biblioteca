public class Author : IEntity
{
    public int Id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }

    public IEnumerable<Book> Books { get; set; }


}
