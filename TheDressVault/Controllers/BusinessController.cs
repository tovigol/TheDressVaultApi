using AutoMapper;
using Dresses.Core.DTO;
using Dresses.Core.Entities;
using Dresses.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheDressVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IDressService _dressService;
        private readonly IMapper _mapper;
        public DressesController(IDressService dressService, IMapper mapper)
        {
            _dressService = dressService;
            _mapper = mapper;
        }

        // GET: api/<DressesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok((_mapper.Map<List<DressDto>>(_dressService.GetDressesAsync())));
        }

        // GET api/<DressesController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var s = _dressService.GetByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DressDto>(s));
        }
        [Authorize(Policy = "OnlyManager")]
        // POST api/<DressesController>
        [HttpPost]
        public ActionResult Post([FromBody] Dress newDress)
        {

            _dressService.AddAsync(newDress);
            return Ok();
        }
        [Authorize(Policy = "OnlyManager")]
        // PUT api/<DressesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Dress value)
        {
            var existingDress = _dressService.GetByIdAsync(id);
            if (existingDress == null)
            {

                return NotFound(new { Message = $"Dress with ID {id} not found." });
            }

            _dressService.UpdateAsync(value, id);

            return NoContent();

        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
