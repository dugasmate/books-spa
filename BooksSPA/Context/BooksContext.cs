using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksSPA.Context
{
    public class BooksContext
    {
        public class BooksContext : DbContext
        {
            public DbSet<Book> Books { get; set; }

            public BooksContext(DbContextOptions<BooksContext> options) : base(options)
            {

            }
        }
    }
}
