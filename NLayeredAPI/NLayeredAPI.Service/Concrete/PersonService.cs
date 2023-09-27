using AutoMapper;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;
using NLayeredAPI.Data.UOW.Abstract;
using NLayeredAPI.Dto.Dtos;
using NLayeredAPI.Service.Abstract;

namespace NLayeredAPI.Service.Concrete
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IGenericRepository<Person> _genericRepository;

        public PersonService(IGenericRepository<Person> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(genericRepository, mapper, unitOfWork)
        {
            _genericRepository = genericRepository;
        }

    }
}
