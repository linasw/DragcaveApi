using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragcaveRepository;
using Microsoft.AspNetCore.Mvc;

namespace DragcaveApi.Controllers
{
    [Route("api/[controller]")]
    public class DragonController : Controller
    {
        private readonly IRepository _repository;

        public DragonController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDragon(Guid id)
        {
            var dragon = _repository.GetDragonAsync(id);

            return View(dragon);
        }
    }
}