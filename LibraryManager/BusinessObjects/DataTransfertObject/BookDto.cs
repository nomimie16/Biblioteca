namespace BusinessObjects.DataTransfertObject
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Type { get; set; }
        public AuthorDto? Author { get; set; }
    }
}