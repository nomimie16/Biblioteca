using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Hosting.BookControllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;
        public BookController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _catalogManager.GetCatalog();
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            return _catalogManager.FindBook(id);
        }

        [HttpGet("type/{type}")]
        public IEnumerable<Book> GetByType(string Type)
        {
            return _catalogManager.GetCatalog(Enum.Parse<TypeBook>(Type));
        }

        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            return _catalogManager.AddBook(book);
        }

        [HttpGet("top-rated")]
        public Book GetTopRated()
        {
            return _catalogManager.GetCatalog().MaxBy(b => b.Rate);
        }

        [HttpDelete("{id}")]
        public void DeleteBook(int id)
        {
            _catalogManager.DeleteBook(id);
        }
    }
}
