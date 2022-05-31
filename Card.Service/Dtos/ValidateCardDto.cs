using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Service.Dtos
{
    public class ValidateCardDto
    {
        public Guid CardId { get; set; }
        public long Token { get; set; }
        public int Cvv { get; set; }
        public int CustomerId { get; set; }
        public ValidateCardDto(Guid cardId, long token, int cvv, int customerId)
        {
            CardId = cardId;
            Token = token;
            Cvv = cvv;
            CustomerId = customerId;
        }

        public ValidateCardDto()
        {
        }
    }
}
