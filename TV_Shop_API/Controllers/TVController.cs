using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TV_Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVController : ControllerBase
    {
        private readonly TVShopDbContext context;
        private readonly ITVService tvService;

        public TVController(TVShopDbContext context, ITVService tvService)
        {
            this.context = context;
            this.tvService = tvService;
        }

        //[HttpGet("/all")] // GET: ~/all
        [HttpGet("all")]    // GET: ~/api/laptops/all
        public IActionResult GetAll()
        {
            return Ok(tvService.GetAll());
        }

        // put data to action
        // 1 - [FromQuery]: ~/api/laptops/get?id=2
        // 2 - [FromRoute]: ~/api/laptops/get/2

        [HttpGet("get/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var tv = tvService.GetById(id);

            if (tv == null) return NotFound();

            return Ok(tv);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TVDto tv)
        {
            // check metadata validations
            if (!ModelState.IsValid) return BadRequest();

            tvService.Create(tv);

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] TVDto tv)
        {
            if (!ModelState.IsValid) return BadRequest();

            tvService.Edit(tv);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            tvService.Delete(id);

            return Ok();
        }
    }
}
