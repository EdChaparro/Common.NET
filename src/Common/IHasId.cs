using System;

namespace IntrepidProducts.Common
{
    public interface IHasId
    {
        public Guid Id { get; }
    }

    public interface IEntity : IHasId
    { }

    public abstract class AbstractEntity : IHasId, IEntity
    {
        protected AbstractEntity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; } //private setter used by EF (via Reflection).
    }

}