using NLayeredAPI.Data.Context;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;

namespace NLayeredAPI.Data.Repository.Concrete
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
