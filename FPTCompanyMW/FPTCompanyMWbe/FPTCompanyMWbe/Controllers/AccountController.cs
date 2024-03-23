using FPTCompanyMWbe.Model.Request;
using FPTCompanyMWbe.Models;
using FPTCompanyMWbe.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FPTCompanyMWbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var data = _accountService.Login(request.Email, request.Password);
            if(data != null)
                return Ok(data);
            return Ok(null);
        }
    }
}