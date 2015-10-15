namespace AvenueEntrega.Model.Repository
{
    public interface IUnitOfWorkRepository<TEntity> where TEntity : IAggregateRoot
    {
        void SaveCreated(TEntity entity);
        void SaveAmended(TEntity entity);
        void SaveDeleted(TEntity entity);
        void Persist();
    }
}