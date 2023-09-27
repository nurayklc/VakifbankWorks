using NLayeredAPI.Data.Context;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;

namespace NLayeredAPI.Data.Repository.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
