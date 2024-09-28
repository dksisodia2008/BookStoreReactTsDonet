using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Book
{
    
    public class BookDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = "No Title";
        public string Author { get; set; } = string.Empty;
        public string Language { get; set; } = String.Empty;
        public DateTime PublicationDate { get; set; } = System.DateTime.Now;
        public DateTime UpateAt { get; set; } = System.DateTime.Now;

    }
}
