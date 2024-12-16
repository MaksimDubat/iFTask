using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Application.Services.Implementations
{
    /// <summary>
    /// Service to receive authors, that match the terms.
    /// </summary>
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;
        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Author, who wrote the book with the longest title ( if there are several such authors, the author must be returned with the smallest Id).
        /// </summary>
        public async Task<Author> GetAuthor()
        {
            return await _context.Authors
                .Where(a => a.Books.Any())
                .OrderBy(a => a.Id)
                .Select(a => new
                {
                    Author = a,
                    LongestTitle = a.Books.Max(b => b.Title.Length)
                })
                .OrderByDescending(a => a.LongestTitle)
                .ThenBy(a => a.Author.Id)
                .Select(a => a.Author)
                .FirstOrDefaultAsync();
        }
        /// <summary>
        ///  Authors, who have written an equal number of books published after 2015.
        /// </summary>
        public async Task<List<Author>> GetAuthors()
        {
            var date = new DateTime(2015, 1, 1);
            return await _context.Authors
               .Where(a => a.Books.Count(b => b.PublishDate > date) % 2 ==0)
               .ToListAsync();
        }
    }
}
