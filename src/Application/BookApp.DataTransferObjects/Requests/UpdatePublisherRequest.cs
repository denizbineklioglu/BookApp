using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataTransferObjects.Requests
{
    public class UpdatePublisherRequest
    {
        public int PublisherID { get; set; }
        public string Name { get; set; }
    }
}
