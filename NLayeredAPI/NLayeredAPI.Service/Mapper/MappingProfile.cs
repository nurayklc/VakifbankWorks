using AutoMapper;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Dto.Dtos;

namespace NLayeredAPI.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
