using AutoMapper;
using Dresses.Core.DTO;
using Dresses.Core.Entities;
using Dresses.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheDressVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;
        private readonly IMapper _mapper;
        public BusinessController(IBusinessService businessService, IMapper mapper)
        {
            _businessService = businessService;
            _mapper = mapper;
        }

        // GET: api/<DressesController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok((_mapper.Map<List<Business>>(await _businessService.GetBusinessAsync())));
        }

        // GET api/<DressesController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var s =await _businessService.GetBusinessByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Business>(s));
        }
        [Authorize(Policy = "OnlyManager")]
        // POST api/<DressesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Business newBusiness)
        {

            if (!User.IsInRole(UserRole.SuperAdmin.ToString()))
            {
                return Unauthorized("רק מנהל המערכת הראשי יכול להוסיף עסקים חדשים.");
            }
           await _businessService.AddBusinessAsync(newBusiness);
            
            
            return Ok("העסק נוסף בהצלחה!");

          
        }
        [Authorize(Policy = "OnlyManager")]
        // PUT api/<DressesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Business value)
        {
            var existingDress =await _businessService.GetBusinessByIdAsync(id);
            if (existingDress == null)
            {

                return NotFound(new { Message = $"Dress with ID {id} not found." });
            }

            await _businessService.UpdateBusinessAsync(value, id);

            return NoContent();

        }
       
    }
}
