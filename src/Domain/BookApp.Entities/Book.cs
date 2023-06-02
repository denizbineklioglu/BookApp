using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities
{
	public class Book: IEntity
	{
        [Key]
        public int BookID { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public int WriterID { get; set; }
        public Writer Writer { get; set; }

		public int CategoryID { get; set; }
		public Category Category { get; set; }

		public int PublisherID { get; set; }
		public Publisher Publisher { get; set; }

    }
}
