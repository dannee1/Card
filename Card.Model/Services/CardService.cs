using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Card.Domain.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICacheService _cacheService;

        public CardService(ICardRepository cardService, ICacheService cacheService)
        {
            _cardRepository = cardService;
            _cacheService = cacheService;
        }

        public CustomerCard Get(Guid id)
        {
            return _cardRepository.Get(id);
        }

        public CustomerCard Save(CustomerCard card)
        {
            _cardRepository.Save(card);
            card.Token = GenerateToken(card.CardNumber, card.Cvv);
            return card;
        }

        public long GenerateToken(long cardNumber, int cvv)
        {
            if (cardNumber > 0 && cvv > 0)
            {
                long token = NewToken(cardNumber, cvv);
                long cachedValue = _cacheService.CacheToken(token);
                return cachedValue;
            }
            return 0;            
        }

        

        private static long NewToken(long cardNumber, int cvv)
        {
            var last4 = cardNumber.ToString().Substring(cardNumber.ToString().Length - 4, 4).ToCharArray();

            int rotationTimes = cvv;

            for (int i = 0; i < rotationTimes; i++)
            {
                last4 = rotate(last4);
            }
            var token = Convert.ToInt64(string.Join("", last4));
            return token;
        }

        private static char[] rotate(char[] itens)
        {
            char temp;
            for (int j = 0; j < itens.Length - 1; j++)
            {
                temp = itens[0];
                itens[0] = itens[j + 1];
                itens[j + 1] = temp;
            }

            return itens;
        }

        public bool Validate(Guid cardId, int customerId, int cvv, long token)
        {
            bool result = true;
            CustomerCard savedCard = _cardRepository.Get(cardId);
            if (savedCard != null)
            {
                Console.WriteLine(savedCard.CardNumber);

                if (!validTokenByTime(token))
                {
                    result = false;
                }
                else if (savedCard.CustomerId != customerId)
                {
                    result = false;
                }
                else if (NewToken(savedCard.CardNumber, cvv) != token)
                {
                    result =  false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        private bool validTokenByTime(long token)
        {
            return _cacheService.Get(token) != null;
        }
    }
}
