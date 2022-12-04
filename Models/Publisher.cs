using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        public  string PName { get; set;}
        public string PAddress { get; set; }

        public string PMobile { get; set;}
    }
}
