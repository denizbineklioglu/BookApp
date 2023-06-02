using BookApp.DataTransferObjects.Requests;
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
	}
}
