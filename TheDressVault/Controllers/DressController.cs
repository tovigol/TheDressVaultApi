
using Microsoft.AspNetCore.Mvc;
using Dresses.Core.Entities;
using Dresses.Core.Services;
using AutoMapper;
using Dresses.Core.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheDressVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DressesController : ControllerBase
    {
        private readonly IDressService _dressService;
        private readonly IMapper _mapper;
        public DressesController(IDressService dressService, IMapper mapper)
        {
            _dressService = dressService;
            _mapper=mapper;
        }

        // GET: api/<DressesController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok((_mapper.Map< List<DressDto>>(_dressService.GetDressesAsync())));
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

        // POST api/<DressesController>
        [HttpPost]
        public ActionResult Post([FromBody] Dresess newDress)
        {
            //var s = new Dress{ name =newDress.name, description= newDress .description, size= newDress.size, rental_price= newDress.rental_price};
             _dressService.AddAsync(newDress);
            return Ok();
        }

        // PUT api/<DressesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Dresess value)
        {
            var existingDress = _dressService.GetByIdAsync(id);
            if (existingDress == null)
            {
     
                return NotFound(new { Message = $"Dress with ID {id} not found." });
            }

            _dressService.UpdateAsync(value, id);

            return NoContent();

        }

        // DELETE api/<DressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
