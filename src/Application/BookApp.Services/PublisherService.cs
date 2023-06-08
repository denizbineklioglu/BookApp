using AutoMapper;
using BookApp.DataTransferObjects.Requests;
using BookApp.DataTransferObjects.Responses;
using BookApp.Entities;
using BookApp.Infrastructure.Migrations;
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

        public async Task DeletePublisherAsync(int id)
        {
            await _publisherRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<UpdatePublisherRequest> GetByIdUpdate(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            return _mapper.Map<UpdatePublisherRequest>(publisher);
        }

        public IEnumerable<PublisherDisplayResponse> GetPublishersForList()
        {
            var publishers = _publisherRepository.GetAll();
            var response = _mapper.Map<IEnumerable<PublisherDisplayResponse>>(publishers);
            return response;
        }

        public async Task UpdatePublisherAsync(UpdatePublisherRequest updatePublisherRequest)
        {
            var publisher = _mapper.Map<Publisher>(updatePublisherRequest);
            await _publisherRepository.UpdateAsync(publisher);
        }
    }
}
