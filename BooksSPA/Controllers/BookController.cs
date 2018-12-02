using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksSPA.Models;
using BooksSPA.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksSPA.Controllers
{
    public class BookController : Controller
    {
        private BookRepository bookRepository;

        public BookController (BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            var books = bookRepository.ReadAllAsync();
            return Ok(books);
        }

        [HttpGet("{author}/{title}")]
        public async Task<IActionResult> Add(string author, string title)
        {
            var book = new Book
            {
                Author = author, Title = title
        };
            await bookRepository.CreateAsync(book);
            return RedirectToAction("index");
        }
    }
}
