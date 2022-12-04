using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BookBorrower
    {
        [Key]
        public int CardNo { get; set; }
        
        public string BName { get; set; }
         public string BEmail { get; set; }
        public string BAddress { get; set; } 

        public int BooksIssued { get; set; }
    }
}
