using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;

namespace NLayeredAPI.Data.UOW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        Task CompleteAsync();
    }
}
