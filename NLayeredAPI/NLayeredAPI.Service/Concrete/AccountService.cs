using AutoMapper;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;
using NLayeredAPI.Data.UOW.Abstract;
using NLayeredAPI.Dto.Dtos;
using NLayeredAPI.Service.Abstract;

namespace NLayeredAPI.Service.Concrete
{
    public class AccountService : BaseService<AccountDto, Account>, IAccountService
    {
        private readonly IGenericRepository<Account> _genericRepository;
        public AccountService(IGenericRepository<Account> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(genericRepository, mapper, unitOfWork)
        {
            _genericRepository = genericRepository;
        }
    }
}
