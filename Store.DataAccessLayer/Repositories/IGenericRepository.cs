using Store.Entities.Common.baseEntity;


namespace Store.DataAccessLayer.Repositories
{
    public interface IGenericRepository<TEntity>: IDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity?> GetEntityById(double id);
        Task AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);

        Task DeleteEntityById(long id);

        void DeleteEntity(TEntity entity);

        Task SaveChanges();


    }
}
