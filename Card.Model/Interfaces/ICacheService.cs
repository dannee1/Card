
using Card.Domain.Entities.CardAggregate;
using System;

namespace Card.Domain.Interfaces
{
    public interface ICacheService
    {
        long CacheToken(long token);
        object Get(long token);
    }
}