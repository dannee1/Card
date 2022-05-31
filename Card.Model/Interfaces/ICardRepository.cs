using Card.Domain.Entities.CardAggregate;
using System;

namespace Card.Domain.Interfaces
{
    public interface ICardRepository
    {
        CustomerCard Get(Guid id);
        void Save(CustomerCard card);
    }
}
