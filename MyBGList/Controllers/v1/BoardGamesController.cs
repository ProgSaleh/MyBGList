using Microsoft.AspNetCore.Mvc;


namespace MyBGList.Controllers.v1
{
    [Route("/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BoardGamesController : ControllerBase
    {
        private readonly ILogger<BoardGamesController> _logger;

        public BoardGamesController(ILogger<BoardGamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBoardGames")]
        // Cache this response for 60sec 
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60, NoStore = true)]
        public DTO.v1.RestDTO<BoardGame[]> Get()
        {
            _logger.LogInformation("Saleh>>> visited the action method!");
            return new DTO.v1.RestDTO<BoardGame[]>()
            {
                Data = new BoardGame[]
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
                Links = new List<DTO.v1.LinkDTO>
                {
                    new DTO.v1.LinkDTO(
                        Url.Action(null, "BoardGames", null, Request.Scheme)!,
                        "self",
                        "GET"
                    )
                }
            };
        }

    }
}
