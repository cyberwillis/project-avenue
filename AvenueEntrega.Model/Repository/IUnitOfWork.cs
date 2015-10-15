namespace AvenueEntrega.Model.Repository
{
    public interface IUnitOfWork<TEntity> where TEntity : IAggregateRoot
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Commit();
    }
}