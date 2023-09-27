using Microsoft.EntityFrameworkCore;
using NLayeredAPI.Data.Context;
using NLayeredAPI.Data.Repository.Abstract;

namespace NLayeredAPI.Data.Repository.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<TEntity> _entities;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _entities = _appDbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void RemoveAsync(TEntity entity)
        {
            //var data = _entities.GetType().GetProperty("IsDeleted");
            //if (data != null)
            //{
            //    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            //}
            //else
            _entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

    }
}
