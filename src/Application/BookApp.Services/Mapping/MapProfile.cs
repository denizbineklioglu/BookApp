using AutoMapper;
using BookApp.DataTransferObjects.Requests;
using BookApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Services.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<CreateWriterRequest, Writer>();
			CreateMap<AppUserRegisterRequest, AppUser>();
			CreateMap<AppUserLoginRequest, AppUser>();
		}
	}
}
