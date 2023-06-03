using AutoMapper;
using BookApp.DataTransferObjects.Requests;
using BookApp.DataTransferObjects.Responses;
using BookApp.Entities;
using BookApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task CreatePublisherAsync(CreatePublisherRequest createPublisherRequest)
        {
            var publisher = _mapper.Map<Publisher>(createPublisherRequest);
            await _publisherRepository.CreateAsync(publisher);
        }

        public IEnumerable<PublisherDisplayResponse> GetPublishersForList()
        {
            var publishers = _publisherRepository.GetAll();
            var response = _mapper.Map<IEnumerable<PublisherDisplayResponse>>(publishers);
            return response;
        }
    }
}
