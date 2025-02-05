﻿namespace BubberDinner.Domain.Models
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
        where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }
        protected AggregateRoot(TId id) : base(id)
        {
        }

        protected AggregateRoot()
        {

        }
    }
}
