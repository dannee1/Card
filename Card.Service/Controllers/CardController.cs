using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Card.Domain.Entities;
using Card.Domain.Entities.CardAggregate;
using Card.Domain.Interfaces;
using Card.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Card.Service.Controllers
{
    [Route("api/card")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Save a new customer card
        /// </summary>
        [HttpPost("/save")]
        public IActionResult Post(SaveCardDto saveCardDto)
        {
            CustomerCard savedCard = _cardService.Save(new CustomerCard(saveCardDto.CustomerId, saveCardDto.CardNumber, saveCardDto.Cvv));
            SavedCardDto savedCardDto = new SavedCardDto(savedCard.Id, savedCard.Token, savedCard.RegistrationDate.ToUniversalTime());

            return Ok(savedCardDto);

        }

        /// <summary>
        /// Validate a customer card
        /// </summary>
        [HttpPost("/validate")]
        public IActionResult Validate(ValidateCardDto validateCardDto)
        {
            return Ok(this._cardService.Validate(validateCardDto.CardId, validateCardDto.CustomerId, validateCardDto.Cvv, validateCardDto.Token));           
        }
    }
}
