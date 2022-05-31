using Card.Domain.Entities;
using Card.Domain.Entities.CardAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Card.Domain.Factories
{
    public class CardFactory
    {
        public static CustomerCard Create(int customerId, int cardNumber, int cvv)
        {
            return new CustomerCard(customerId, cardNumber, cvv);         
        }
    }
}
