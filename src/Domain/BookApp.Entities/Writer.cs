using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities
{
	public class Writer : IEntity
	{
        [Key]
        public int WriterID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
