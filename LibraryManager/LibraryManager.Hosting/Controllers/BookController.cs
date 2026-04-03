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
        public IActionResult GetAll()
        {
            return Ok(_catalogManager.GetCatalog());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _catalogManager.FindBook(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpGet("type/{type}")]
        public IActionResult GetByType(string type)
        {
            return Ok(_catalogManager.GetCatalog(Enum.Parse<TypeBook>(type, ignoreCase: true)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            return Ok(_catalogManager.AddBook(book));
        }

        [HttpGet("top-rated")]
        public IActionResult GetTopRated()
        {
            return Ok(_catalogManager.GetCatalog().MaxBy(b => b.Rate));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _catalogManager.DeleteBook(id);
            return NoContent();
        }
    }
}
