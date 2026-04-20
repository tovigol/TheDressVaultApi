using AutoMapper;
using Dresses.Core.DTO;
using Dresses.Core.Entities;
using Dresses.Core.Services;
using Dresses.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheDressVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;
        public UserController(IUserService UserService, IMapper mapper)
        {
            _UserService = UserService;
            _mapper = mapper;
        }
        [Authorize(Policy = "OnlyManager")]
        // GET: api/<UserController>

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok((_mapper.Map<List<UserDto>>(await _UserService.GetUsersAsync())));
        }
        [Authorize(Policy = "OnlyManager")]
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            var s = await _UserService.GetByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(s));
        }


        // POST api/<UserController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Users newuser)
        {
          await  _UserService.AddAsync(newuser);
            return  Ok();
        }

        // PUT api/<UserController>/5
        [Authorize(Roles = "Customer")]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Users value)
        {

            var existingDress = _UserService.GetByIdAsync(id);
            if (existingDress == null)
            {

                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            _UserService.UpdateAsync(value,id);

            return NoContent();

        }
            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
      
    }
}
