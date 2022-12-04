using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BookIssue
    {
        [Key]
        public int IssueId { get; set; }
        public int CardNo { get; set; }
        public string ISBN { get; set; }
        public DateTime DueDate { get; set; }
    }
}
