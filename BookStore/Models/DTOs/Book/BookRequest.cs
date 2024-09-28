using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Book
{
    public class BookRequest
    {
        public string Title { get; set; } = "No Title";
        public string Author { get; set; } = string.Empty;
        public string Language { get; set; } = String.Empty;
    }
}
