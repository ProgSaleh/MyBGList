﻿using Microsoft.AspNetCore.Mvc;
using MyBGList.DTO;

namespace MyBGList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly ILogger<BoardGamesController> _logger;

        public BoardGamesController(ILogger<BoardGamesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBoardGames")]
        // Cache this response for 60sec 
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 60)]
        public RestDTO<BoardGame[]> Get()
        {
            _logger.LogInformation("Saleh>>> visited the action method!");
            return new RestDTO<BoardGame[]>()
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
                Links = new List<LinkDTO>
                {
                    new LinkDTO(
                        Url.Action(null, "BoardGames", null, Request.Scheme)!,
                        "self",
                        "GET"
                    )
                }
            };
        }

    }
}
