using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.StoreDbContext;
using Store.Entities.Common.baseEntity;

namespace Store.DataAccessLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region constractor

        private readonly StoreContext _Context;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(StoreContext context)
        {
            _Context = context;
            _dbSet = _Context.Set<TEntity>();


        }

        #endregion


        public async Task AddEntity(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public void DeleteEntity(TEntity entity)
        {
            entity.IsDeleted = true;
            UpdateEntity(entity);
        }

        public async Task DeleteEntityById(long id)
        {
            TEntity? singleEntityResulte = await GetEntityById(id);
            if(singleEntityResulte != null)
            {
                DeleteEntity(singleEntityResulte);
            }
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable<TEntity>().Where(i => i.IsDeleted == false);
        }

        public async Task<TEntity?> GetEntityById(double id)
        {
            TEntity? singleEntityResult = await _dbSet.SingleOrDefaultAsync<TEntity>(entity =>
                entity.id == id &&
                entity.IsDeleted == false
            );
            return singleEntityResult;
        }

        public async Task SaveChanges()
        {
            await _Context.SaveChangesAsync();
        }

        public void UpdateEntity(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
