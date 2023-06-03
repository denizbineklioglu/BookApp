using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataTransferObjects.Requests
{
    public class CreateBookRequest
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        public int WriterID { get; set; }
        public int PublisherID { get; set; }
    }
}
