using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using apis.Services;
using apis.Models;
using apis.Dtos;

namespace apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyGroupsController : ControllerBase
    {
        private readonly SqlDataService service;

        public SpotifyGroupsController()
        {
            service = new SqlDataService();
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<SpotifyGroup>> Groups()
        {
            return Ok(service.GetAll());
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] CreateSpotifyGroupDto group)
        {
            SpotifyGroup groupToCreate = new ()
            {
                Id = Guid.NewGuid(),
                Name = group.Name
            };

            service.Post(groupToCreate);

            return Ok();
        }
    }
}
