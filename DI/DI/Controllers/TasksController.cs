using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DI.Core.Contracts;
using DI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ICrudRepository<DI.Core.Entities.Task, Guid> crudRepository;
        public TasksController(ICrudRepository<DI.Core.Entities.Task, Guid> crudRepository)
        {
            this.crudRepository = crudRepository;
        }
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