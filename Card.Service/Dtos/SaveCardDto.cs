using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Card.Service.Dtos
{
    public class SaveCardDto
    {
        public SaveCardDto()
        {
        }

        public SaveCardDto(int customerId, long cardNumber, int cvv)
        {
            CustomerId = customerId;
            CardNumber = cardNumber;
            Cvv = cvv;
        }

        public int CustomerId { get; set; }
        [Range(1, 9999999999999999, ErrorMessage = "Value must be between 1 to 9999999999999999")]
        public long CardNumber { get; set; }
        [Range(1, 99999, ErrorMessage = "Value must be between 1 to 99999")]

        public int Cvv { get; set; }
    }
}
