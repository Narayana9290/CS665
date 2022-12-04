using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class LibraryDbContext :DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Books> Books { get; set; }

        public DbSet<BookBorrower> BookBorrower { get; set; }

        public DbSet<BookIssue> BookIssue { get; set; }



    }
}
