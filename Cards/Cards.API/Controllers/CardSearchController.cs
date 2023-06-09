using Cards.Data;
using Cards.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{    
    [Produces("application/json")]
    [Route("api/cards/search")]
    [ApiController]
    public class CardSearchController : ControllerBase
    {
        private readonly ILogger<CardSearchController> _logger;
        private readonly ICardsRepository _cardsRepository;

        public CardSearchController
            (
            ILogger<CardSearchController> logger,
            ICardsRepository cardsRepository
            )
        {
            _logger = logger;
            _cardsRepository = cardsRepository;
        }

        /// <summary>
        /// Searches the card collection and returns any that match the provided name.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Collection of playing cards.</response>
        /// <response code="400">If provided input is invalid.</response>
        /// <response code="403">If not authorised, ensure all headers are provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("by-name/{name}")]
        [Produces(typeof(BasicCard[]))]
        [ProducesResponseType(typeof(BasicCard[]), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult FindCardsByName([FromRoute] string name)
        {
            return Ok(_cardsRepository.FindCardsByName(name));
        }

        /// <summary>
        /// Searches the card collection and returns any that match the provided cost of the card.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Collection of playing cards.</response>
        /// <response code="400">If provided input is invalid.</response>
        /// <response code="403">If not authorised, ensure all headers are provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("by-cost/{cost:int}")]
        [Produces(typeof(BasicCard[]))]
        [ProducesResponseType(typeof(BasicCard[]), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult FindCardsByCost([FromRoute] int cost)
        {
            return Ok(_cardsRepository.FindCardsByCost(cost));
        }

        /// <summary>
        /// Searches the card collection and returns any that match the provided health of the card.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Collection of playing cards.</response>
        /// <response code="400">If provided input is invalid.</response>
        /// <response code="403">If not authorised, ensure all headers are provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("by-health/{health:int}")]
        [Produces(typeof(BasicCard[]))]
        [ProducesResponseType(typeof(BasicCard[]), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult FindCardsByHealth([FromRoute] int health)
        {
            return Ok(_cardsRepository.FindCardsByHealth(health));
        }

        /// <summary>
        /// Searches the card collection and returns any that match the provided attack of the card.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Collection of playing cards.</response>
        /// <response code="400">If provided input is invalid.</response>
        /// <response code="403">If not authorised, ensure all headers are provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("by-attack/{attack:int}")]
        [Produces(typeof(BasicCard[]))]
        [ProducesResponseType(typeof(BasicCard[]), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult FindCardsByAttack([FromRoute] int attack)
        {
            return Ok(_cardsRepository.FindCardsByAttack(attack));
        }

        /// <summary>
        /// Searches the card collection and returns any that match the description cost of the card.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Collection of playing cards.</response>
        /// <response code="400">If provided input is invalid.</response>
        /// <response code="403">If not authorised, ensure all headers are provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("by-description/{description}")]
        [Produces(typeof(BasicCard[]))]
        [ProducesResponseType(typeof(BasicCard[]), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult FindCardsByDescription([FromRoute] string description)
        {
            return Ok(_cardsRepository.FindCardsByName(description));
        }
    }
}