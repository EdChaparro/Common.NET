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

        public virtual bool IsValid()
        {
            return true;
        }

        #region Equality
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as AbstractEntity;

            return other != null && Equals(other);
        }

        protected bool Equals(AbstractEntity other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}