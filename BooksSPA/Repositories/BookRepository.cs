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

        public BookRepository(BooksContext stockContext)
        {
            this.booksContext = stockContext;
        }

        public async Task CreateAsync(Book book)
        {
            await booksContext.Books.AddAsync(book);
            await booksContext.SaveChangesAsync();
        }

        public async Task<Book> ReadAsync(long id)
        {
            var selectedBook = await booksContext.Books.FindAsync(id);
            return selectedBook;
        }

        public async Task<List<Book>> ReadAllAsync()
        {
            var books = await booksContext.Books.ToListAsync();
            return books;
        }

        public async Task UpdateAsync(Book book)
        {
            booksContext.Books.Update(book);
            await booksContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            booksContext.Books.Remove(book);
            await booksContext.SaveChangesAsync();
        }
    }
}
