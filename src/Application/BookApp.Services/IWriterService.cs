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
	public interface IWriterService 
	{
		Task CreateWriterAsync(CreateWriterRequest createWriterRequest);
        IEnumerable<WriterDisplayResponse> GetWritersForList();
		Task DeleteWriterAsync(int id);

        Task<UpdateWriterRequest> GetByIdUpdate(int id);
		Task UpdateWriterAsync(UpdateWriterRequest updateWriterRequest);
		Task<IEnumerable<Writer>> GetAll();
    }
}
