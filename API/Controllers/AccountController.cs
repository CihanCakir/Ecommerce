using System;
using System.Threading.Tasks;
using API.Dtos.Accout;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper, IMailService mailService)
        {
            _mailService = mailService;
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var user = await _userManager.FindByUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            user.Address = _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new ApiResponse(401));

            }
            else
            {
                //  await _mailService.SendEmailAsync(loginDto.Email, "New Login", "<h1> Hey ! new login to ypır account noticed</h1> <p>New login to your account at " + DateTime.Now + " </p>");
                return new UserDto
                {
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                    DisplayName = user.DisplayName
                };
            }

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Email address is in use" } });
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            // Email Confirmation
            // var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            // var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
            // var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

            //string url = $"{_configr}"
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));
            //     await _userManager.AddToRoleAsync(user,"Custmer");
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }

        private object ConfirmEmail()
        {
            throw new NotImplementedException();
        }
    }
}