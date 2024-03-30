using Microsoft.AspNetCore.Mvc;

namespace MyBGList.Controllers.v2
{
    [Route("/v{version:ApiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class BoardGamesController : ControllerBase
    {
        private readonly ILogger<BoardGamesController> _logger;

        public BoardGamesController(ILogger<BoardGamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBoardGames")]
        // Cache this response for 60sec 
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 120)]
        public DTO.v2.RestDTO<BoardGame[]> Get()
        {
            _logger.LogInformation("Saleh>>> visited the action method!");
            return new DTO.v2.RestDTO<BoardGame[]>()
            {
                Items = new BoardGame[]
                {
                    new BoardGame()
                    {
                        Id = 1,
                        Name = "Axis & Allies",
                        Year = 1981,
                    },
                    new BoardGame()
                    {
                        Id = 2,
                        Name = "Citadels",
                        Year = 2000
                    },
                    new BoardGame()
                    {
                        Id = 3,
                        Name = "Terraforming Mars",
                        Year = 2016
                    }
                },
                Links = new List<DTO.v2.LinkDTO>
                {
                    new DTO.v2.LinkDTO(
                        Url.Action(null, "BoardGames", null, Request.Scheme)!,
                        "self",
                        "GET"
                    )
                }
            };
        }

    }
}
