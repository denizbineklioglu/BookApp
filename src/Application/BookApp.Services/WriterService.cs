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
	public class WriterService : IWriterService
	{
		private readonly IWriterRepository _writerRepository;
		private readonly IMapper _mapper;

		public WriterService(IWriterRepository writerRepository, IMapper mapper)
		{
			_writerRepository = writerRepository;
			_mapper = mapper;
		}

		public async Task CreateWriterAsync(CreateWriterRequest createWriterRequest)
		{
			var writer = _mapper.Map<Writer>(createWriterRequest);
			await _writerRepository.CreateAsync(writer);
		}

        public async Task DeleteWriterAsync(int id)
        {
            await _writerRepository.DeleteAsync(id);
        }

        public IEnumerable<Writer> GetAll()
        {
           return _writerRepository.GetAll();
        }

        public UpdateWriterRequest GetByIdUpdate(int id)
        {
			var writer = _writerRepository.GetById(id);
			return _mapper.Map<UpdateWriterRequest>(writer);
        }

        public IEnumerable<WriterDisplayResponse> GetWritersForList()
        {
			var writers = _writerRepository.GetAll();
			var response = _mapper.Map<IEnumerable<WriterDisplayResponse>>(writers);
			return response;
        }

        public async Task UpdateWriterAsync(UpdateWriterRequest updateWriterRequest)
        {
			var writer = _mapper.Map<Writer>(updateWriterRequest);
			await _writerRepository.UpdateAsync(writer);
        }
    }
}
