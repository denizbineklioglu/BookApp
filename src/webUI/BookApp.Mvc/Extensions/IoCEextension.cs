using BookApp.Infrastructure.Repositories;
using BookApp.Services;

namespace BookApp.Mvc.Extensions
{
    public static class IoCEextension
    {


        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IWriterService, WriterService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IWriterRepository, EFWriterRepository>();
            services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IPublisherRepository, EFPublisherRepository>();
            return services;
        }


    }
}
