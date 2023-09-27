using AutoMapper;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;
using NLayeredAPI.Data.Repository.Concrete;
using NLayeredAPI.Data.UOW.Abstract;
using NLayeredAPI.Data.UOW.Concrete;
using NLayeredAPI.Service.Abstract;
using NLayeredAPI.Service.Concrete;
using NLayeredAPI.Service.Mapper;

namespace NLayeredAPI.Extension
{
    public static class StartupDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
