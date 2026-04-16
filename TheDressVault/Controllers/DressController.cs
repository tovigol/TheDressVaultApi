
using Microsoft.AspNetCore.Mvc;
using Dresses.Core.Entities;
using Dresses.Core.Services;
using AutoMapper;
using Dresses.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(_mapper.Map<List<DressDto>>(await _dressService.GetDressesAsync()));
        }

        // GET api/<DressesController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var s =await _dressService.GetByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DressDto>(s));
        }
        [Authorize(Policy = "OnlyManager")]
        // POST api/<DressesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Dress newDress)
        {
            
            await _dressService.AddAsync(newDress);
            return Ok();
        }
        [Authorize(Policy = "OnlyManager")]
        // PUT api/<DressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Dress value)
        {
            var existingDress =await _dressService.GetByIdAsync(id);
            if (existingDress == null)
            {
     
                return NotFound(new { Message = $"Dress with ID {id} not found." });
            }

            await _dressService.UpdateAsync(value, id);

            return NoContent();

        }
        [HttpGet("by-business/{businessId}")]
   
        public async Task<ActionResult> GetDressesByBusiness(int businessId)
        {
            
            var dresses = await _dressService.GetByBusinessIdAsync(businessId);

            if (dresses == null) return NotFound();

            return Ok(_mapper.Map<IEnumerable<DressDto>>(dresses));
        }

        // DELETE api/<DressesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
