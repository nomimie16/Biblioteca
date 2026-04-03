using Microsoft.AspNetCore.Mvc;
using BusinessObjects.DataTransfertObject;

namespace LibraryManager.Hosting.BookControllers
{
    [ApiController]
    [Route("books")]
    public class BookController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;
            private BookDto ToDto(Book book)
            {
                return new BookDto
                {
                    Id = book.Id,
                    Name = book.Name,
                    Pages = book.Pages,
                    Type = book.Type.ToString(),
                    Author = book.Author == null ? null : new AuthorDto
                    {
                        FirstName = book.Author.FirstName,
                        LastName = book.Author.LastName
                    }
                };
            }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_catalogManager.GetCatalog().Select(ToDto));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _catalogManager.FindBook(id);
            if (book == null) return NotFound();
            return Ok(ToDto(book));
        }

        [HttpGet("type/{type}")]
        public IActionResult GetByType(string type)
        {
            return Ok(_catalogManager.GetCatalog(Enum.Parse<TypeBook>(type, ignoreCase: true)).Select(ToDto));
        }

        [HttpGet("top-rated")]
        public IActionResult GetTopRated()
        {
            return Ok(ToDto(_catalogManager.GetTopRated()));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            return Ok(ToDto(_catalogManager.AddBook(book)));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _catalogManager.DeleteBook(id);
            return NoContent();
        }
    }
}
