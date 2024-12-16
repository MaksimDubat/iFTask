using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Application.Services.Implementations
{
    /// <summary>
    /// Service to receive books, that match the terms.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get book with the highest published circulation value.
        /// </summary>
        public async Task<Book> GetBook()
        {
            return await _context.Books
                .OrderByDescending(b =>b.Price * b.QuantityPublished)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Get books with the title "Red" and published after the release of the album "Carolus Rex" by Sabaton.
        /// </summary>
        public async Task<List<Book>> GetBooks()
        {
            var carolusRexAlbum = new DateTime(2015, 8, 15, 12, 0, 0);
            return await _context.Books
                .Where(b => b.Title.Contains("Red") &&
                b.PublishDate > carolusRexAlbum)
                .ToListAsync();
        }
    }
}
