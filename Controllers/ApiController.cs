using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoreMaster.Models;
using Microsoft.AspNetCore.Http;

namespace WordApi.Controllers
{
    [ApiController, Route("[controller]/score")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private DataContext _dataContext;

        public ApiController(ILogger<ApiController> logger, DataContext db)
        {
            _dataContext = db;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            return _dataContext.Scores.OrderByDescending(s => s.Total).Take(10).ToArray();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status204NoContent)]
        public Score Get(int id)
        {
            return _dataContext.Scores.FirstOrDefault(s => s.Id == id);
        }
    }
}
