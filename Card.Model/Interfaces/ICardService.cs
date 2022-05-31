
using Card.Domain.Entities.CardAggregate;
using System;

namespace Card.Domain.Interfaces
{
    public interface ICardService
    {
        CustomerCard Get(Guid id);
        CustomerCard Save(CustomerCard card);
        bool Validate(Guid cardId, int customerId, int cvv, long token);
        long GenerateToken(long cardNumber, int cvv);
    }
}