using Microsoft.EntityFrameworkCore;
using Models.DTOs.Book;

namespace Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }   
        public DbSet<BookDto> Books { get; set; }
        
    }
}
