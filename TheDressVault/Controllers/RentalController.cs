using AutoMapper;
using Dresses.Core.DTO;
using Dresses.Core.Entities;
using Dresses.Core.Services;
using Dresses.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheDressVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalsService _rentalService;
        private IRentalsService? rentalService;
        private readonly IMapper _mapper;
        public RentalController(IRentalsService rentalService, IMapper mapper)
        {
            _rentalService = rentalService;
            _mapper= mapper;
    }
        [Authorize(Policy = "OnlyManager")]
        // GET: api/<RentalController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok((_mapper.Map<List<RentalDto>>(await _rentalService.GetRentalsAsync())));

        }
        [Authorize(Policy = "OnlyManager")]
        // GET api/<RentalController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var s =await _rentalService.GetByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RentalDto>(s));
        }


        // POST api/<RentalController>
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Rentals newRental)
        {
           await _rentalService.AddAsync(newRental);
            return Ok();
        }

        // PUT api/<RentalController>/5
        [Authorize(Roles = "Customer")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Rentals value)
        {
            var existingRental =await _rentalService.GetByIdAsync(id);
            if (existingRental == null)
            {

                return NotFound(new { Message = $"Dress with ID {id} not found." });
            }

            await _rentalService.UpdateAsync(value,id);

            return NoContent();

        }
        // DELETE api/<RentalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
