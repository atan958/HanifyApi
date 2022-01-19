using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using apis.Services;
using apis.Models;
using apis.Dtos;
using Microsoft.AspNetCore.Cors;

namespace apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyGroupsController : ControllerBase
    {
        private readonly IDataService service;

        public SpotifyGroupsController(IDataService service)
        {
            this.service = service;
            Console.WriteLine("Creating a new Controller");
        }

        [HttpGet]
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
                Name = group.Name,
                Avatar = (group.Avatar == null || group.Avatar.Length == 0) ? null : group.Avatar
            };

            service.Post(groupToCreate);

            return Ok();
        }
    }
}
