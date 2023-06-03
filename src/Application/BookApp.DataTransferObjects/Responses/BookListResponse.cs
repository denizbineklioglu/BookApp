using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataTransferObjects.Responses
{
    public class BookListResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? WriterName { get; set; }
        public string? PublisherName { get; set; }
        public string? CategoryName { get; set; }

    }
}
