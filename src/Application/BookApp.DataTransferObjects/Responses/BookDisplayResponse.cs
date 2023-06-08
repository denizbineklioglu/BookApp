using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataTransferObjects.Responses
{
    public class BookDisplayResponse
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 1;
        public string? ImageUrl { get; set; }

        public string WriterName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }


    }
}
