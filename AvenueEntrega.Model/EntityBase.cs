namespace AvenueEntrega.Model
{
    public class EntityBase<TId> : ModelBase, IEntityBase<TId>
    {
        public TId Id { get; set; }
    }
}