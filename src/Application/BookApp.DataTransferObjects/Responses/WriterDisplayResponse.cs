using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataTransferObjects.Responses
{
    public class WriterDisplayResponse
    {
        public int WriterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
