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
        public async Task<IActionResult> Index()
        {
            var books = await bookRepository.ReadAllAsync();
            return Ok(books);
        }

        [HttpPost("index")]
        public async Task<IActionResult> Add([FromBody]Book book)
        {
            await bookRepository.CreateAsync(book);
            return RedirectToAction("index");
        }
    }
}
