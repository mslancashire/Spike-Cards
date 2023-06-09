using Cards.Data;
using Cards.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cards.API.Controllers
{    
    [Produces("application/json")]
    [Route("api/cards")]
    [ApiController]    
    public class CardCollectionController : ControllerBase
    {
        private readonly ILogger<CardCollectionController> _logger;
        private readonly ICardsRepository _cardsRepository;

        public CardCollectionController
            (
            ILogger<CardCollectionController> logger,
            ICardsRepository cardsRepository
            )
        {
            _logger = logger;
            _cardsRepository = cardsRepository;
        }

        /// <summary>
        /// Gets all the playing cards.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Collection of playing cards.</response>
        /// <response code="400">If provided input is invalid.</response>
        /// <response code="403">If not authorised, ensure all headers are provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("get-cards")]
        [Produces(typeof(BasicCard[]))]
        [ProducesResponseType(typeof(BasicCard[]), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IEnumerable<BasicCard> GetCards()
        {
            return _cardsRepository.GetCardCollection();
        }
    }
}