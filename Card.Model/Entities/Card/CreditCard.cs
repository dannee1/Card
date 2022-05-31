using Card.Commom.AggregateRoots;
using Card.Commom.Entities;
using System;
using System.Linq;

namespace Card.Domain.Entities.CardAggregate
{
    public class CustomerCard : BaseEntity, IAggregateRoot
    {
        public int CustomerId { get;  set; }
        public long CardNumber { get;  set; }
        public int Cvv { get;  set; }
        public DateTime RegistrationDate { get; internal set; }
        public long Token { get;  set; }

        public CustomerCard(Guid id, int customerId, long cardNumber, int cvv)
        {
            Id = id;
            CustomerId = customerId;
            CardNumber = cardNumber;
            Cvv = cvv;
            RegistrationDate = DateTime.Now;
        }

        public CustomerCard(int customerId, long cardNumber, int cvv)
        {
            CustomerId = customerId;
            CardNumber = cardNumber;
            Cvv = cvv;
            RegistrationDate = DateTime.Now;

        }

       
    }
}
