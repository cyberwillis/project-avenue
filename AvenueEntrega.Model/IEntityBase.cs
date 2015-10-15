namespace AvenueEntrega.Model
{
    public interface IEntityBase<TId> : IAggregateRoot
    {
        TId Id { get; set; }
    }
}