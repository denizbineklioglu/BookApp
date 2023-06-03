using BookApp.DataTransferObjects.Requests;
using BookApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public interface IPublisherService 
    {
        Task CreatePublisherAsync(CreatePublisherRequest createPublisherRequest);
        IEnumerable<PublisherDisplayResponse> GetPublishersForList();
    }
}
