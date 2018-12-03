using BooksSPA.Context;
using BooksSPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksSPA.Repositories
{
    public class BookRepository
    {
        private BooksContext booksContext;

        public BookRepository(BooksContext booksContext)
        {
            this.booksContext = booksContext;
        }

        public async Task CreateAsync(Book book)
        {
            if (!string.IsNullOrWhiteSpace(book.Title) && !string.IsNullOrWhiteSpace(book.Author))
            {
                await booksContext.Books.AddAsync(book);
                await booksContext.SaveChangesAsync();
            }
        }

        public async Task<Book> ReadAsync(long id)
        {
            var selectedBook = await booksContext.Books.FindAsync(id);
            return selectedBook;
        }

        public async Task<List<Book>> ReadAllAsync()
        {
            var books = await booksContext.Books.ToListAsync();
            var sortedBooks = books.OrderBy(x => x.Author).ThenBy(y => y.Title).ToList();
            return sortedBooks;
        }

        public async Task DeleteAsync(long id)
        {
            var book = booksContext.Books.FirstOrDefault(x => x.Id == id);
            booksContext.Books.Remove(book);
            await booksContext.SaveChangesAsync();
        }
    }
}
