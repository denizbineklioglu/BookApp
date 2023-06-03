using BookApp.DataTransferObjects.Requests;
using BookApp.DataTransferObjects.Responses;
using BookApp.Entities;
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

        IEnumerable<Publisher> GetAll();
        Task DeletePublisherAsync(int id);
        UpdatePublisherRequest GetByIdUpdate(int id);
        Task UpdatePublisherAsync(UpdatePublisherRequest updatePublisherRequest);
    }
}
