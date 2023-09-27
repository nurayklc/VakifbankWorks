using NLayeredAPI.Data.Context;
using NLayeredAPI.Data.Model;
using NLayeredAPI.Data.Repository.Abstract;
using NLayeredAPI.Data.Repository.Concrete;
using NLayeredAPI.Data.UOW.Abstract;

namespace NLayeredAPI.Data.UOW.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public bool IsDisposed { get; private set; }
        public IGenericRepository<Account> AccountRepository { get; private set; }
        public IGenericRepository<Person> PersonRepository { get; private set; }
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            AccountRepository = new GenericRepository<Account>(appDbContext);
            PersonRepository = new GenericRepository<Person>(appDbContext);
        }

        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    _appDbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                    _appDbContext.Dispose();
            }
            IsDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
