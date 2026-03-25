public class Book : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pages {  get; set; }
    public TypeBook Type { get; set; }
    public int Rate { get; set; }
    public int Id_author { get; set; }
    public Author Author { get; set; }
    public IEnumerable<Library> Libraries { get; set; }
}
