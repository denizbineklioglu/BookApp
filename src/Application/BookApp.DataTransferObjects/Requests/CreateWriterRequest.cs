using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataTransferObjects.Requests
{
	public class CreateWriterRequest
	{
		[Required(ErrorMessage = "Ad giriniz")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Soy ad giriniz")]
		public string LastName { get; set; }
		public string? Description { get; set; }
	}
}
