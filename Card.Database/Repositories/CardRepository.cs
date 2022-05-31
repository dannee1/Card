using System;
using System.Collections.Generic;
using System.Linq;
using Card.Database.Context;
using Card.Domain.Entities;
using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;

namespace Card.Database.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardContext _context;

        public CardRepository(CardContext context)
        {
            _context = context;
        }

        public CustomerCard Get(Guid id)
        {
            return _context.Cards.Find(id);
        }

        public void Save(CustomerCard card)
        {
            _context.Add(card);
            _context.SaveChanges();
        }
    }
}