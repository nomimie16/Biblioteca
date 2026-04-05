public class BookAuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public string Type { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public string AuthorFullName => $"{AuthorFirstName} {AuthorLastName}";
    public IEnumerable<string> Libraries { get; set; }
}