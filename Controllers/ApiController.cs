using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoreMaster.Models;

namespace WordApi.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private DataContext _dataContext;

        public ApiController(ILogger<ApiController> logger, DataContext db)
        {
            _dataContext = db;
            _logger = logger;
        }
        [HttpGet, Route("[controller]/game")]
        public IEnumerable<Game> GetGame()
        {
            return _dataContext.Games.OrderBy(g => g.Name).ToArray();
        }
        [HttpGet, Route("[controller]/game/{id}")]
        public Game GetGame(int id)
        {
            return _dataContext.Games.FirstOrDefault(g => g.GameId == id);
        }
    }
}
