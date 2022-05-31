using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Service.Dtos
{
    public class SavedCardDto
    {
        public Guid CardId { get; set; }
        public long Token { get; set; }
        public DateTime RegistrationDate { get; set; }

        public SavedCardDto(Guid cardId, long token, DateTime registrationDate)
        {
            CardId = cardId;
            Token = token;
            RegistrationDate = registrationDate;
        }
    }
}
