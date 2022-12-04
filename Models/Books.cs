using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Books
    {
        [Key]
        public  string ISBN { get; set; }
        public int PublisherId { get; set; }

        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public int CopiesAvailable { get; set; }

    }
}
