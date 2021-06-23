using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyrianShop.dataContexts;
using SyrianShop.DTOs;
using SyrianShop.errorHandling;
using SyrianShop.helper;
using SyrianShop.models;
using SyrianShop.repositories;

namespace SyrianShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<TokenDto> Login(UserDto loginUser)
        {
            
            try
            {
                var user=_userRepository.login(loginUser);

                if (user == null)
                {
                    return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest, "Invalid Login Credentials: User Name Or Password"));
                }

                var token = JwtTokenGenerator.GenerateToken(user);

                TokenDto tokenDto = new TokenDto() { Token = token };
                return Ok(tokenDto);

            }
            catch(Exception e)
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return  Ok(users);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        { 
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));
                }

                return Ok(user);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            try
            {
                if(id != user.Id)
                {
                    return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
                }
                var existUser=await _userRepository.Edit(user);
                return Ok(existUser);
            }
            catch
            {
                Boolean isExist = await _userRepository.Exists(id);
                if(!isExist)
                    return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));

                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
       
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                var addedUser = await _userRepository.Add(user);
                return CreatedAtAction("GetUser", new { id = user.Id }, addedUser);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));
                }

                _userRepository.Delete(user);
                return Ok(user);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }

        }

        
    }
}
