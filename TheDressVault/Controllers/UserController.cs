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
        public ActionResult Get()
        {
            return Ok(_mapper.Map<List<UserDto>>(_UserService.GetUsersAsync()));
        }
        [Authorize(Policy = "OnlyManager")]
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var s = _UserService.GetByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(s));
        }


        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] Dress newuser)
        {
            _UserService.AddAsync(newuser);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Dress value)
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
