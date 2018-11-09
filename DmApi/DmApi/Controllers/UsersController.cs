using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DmApi.DTO;
using DmApi.Helpers;
using DmApi.Models;
using DmApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DmApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService pService, IMapper pMapper, IOptions<AppSettings> pAppSettings)
        {
            _userService = pService;
            _mapper = pMapper;
            _appSettings = pAppSettings.Value;
        }

        [HttpPost("authenticate")]
        [Authorize(Roles = "Admin, Dm, Player")]
        public IActionResult Authenticate([FromBody]UserDTO pUserDTO)
        {
            User user = _userService.Authenticate(pUserDTO.Username, pUserDTO.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Roles),
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                user.Id,
                user.Username,
                user.FirstName,
                user.LastName,
                Token = tokenString,
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDTO pUserDTO)
        {
            var user = _mapper.Map<User>(pUserDTO);

            try
            {
                _userService.Create(user, pUserDTO.Password);
                return Ok(new { message = "User registered succesfully" });
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDTO>>(users);
            return Ok(userDtos);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int pId)
        {
            var user = _userService.GetById(pId);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        [Authorize(Roles = "Admin, Dm, Player")]
        [HttpPut("{id}")]
        public IActionResult Update(int pId, [FromBody]UserDTO pUserDTO)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(pUserDTO);
            user.Id = pId;

            try
            {
                // save 
                _userService.Update(user, pUserDTO.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("setrole/{id}")]
        public IActionResult SetRoles(int pId, string pRoles)
        {
            if (_userService.SetRoles(pId, pRoles))
                return Ok();
            return BadRequest("User does not exist");
        }
    }
}
