using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DI.Core.Contracts;
using DI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ICrudRepository<DI.Core.Entities.Task, Guid> crudRepository;
        public TasksController(ICrudRepository<DI.Core.Entities.Task, Guid> crudRepository)
        {
            this.crudRepository = crudRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Returns the response status</response>
        /// <response code="401">Unauthorized access</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(DI.Core.Entities.Task),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [HttpPost("/api/v1/[controller]")]
        public IActionResult Create([FromBody] TaskViewModel model)
        {
            var t = new DI.Core.Entities.Task();
            t.Name = model.Name;
            crudRepository.Add(t);
        
            return Ok(t);
        }
    }
}