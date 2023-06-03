using AutoMapper;
using BookApp.DataTransferObjects.Requests;
using BookApp.DataTransferObjects.Responses;
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
			CreateMap<CreatePublisherRequest, Publisher>();
			CreateMap<CreateBookRequest, Book>();
			CreateMap<Category, CategoryDisplayResponse>();
			CreateMap<Writer, WriterDisplayResponse>();
			CreateMap<Publisher, PublisherDisplayResponse>();

			CreateMap<Book, UpdateBookRequest>();
			CreateMap<UpdateBookRequest, Book>();

            CreateMap<Writer, UpdateWriterRequest>();
            CreateMap<UpdateWriterRequest, Writer>();

            CreateMap<Publisher, UpdatePublisherRequest>();
            CreateMap<UpdatePublisherRequest, Publisher>();


        }
    }
}
