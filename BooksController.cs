using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookQuotes.Api.Data;
using BookQuotes.Api.Models;

namespace BookQuotes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => _db.Books.ToList();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _db.Books.Find(id);
            return book is null ? NotFound() : book;
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Book updated)
        {
            var book = _db.Books.Find(id);
            if (book is null) return NotFound();

            book.Title = updated.Title;
            book.Author = updated.Author;
            book.Published = updated.Published;
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book is null) return NotFound();

            _db.Books.Remove(book);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
