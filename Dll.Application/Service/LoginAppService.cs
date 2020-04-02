using Dll.Application.Interfaces;
using Dll.Application.Model;
using Dll.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Application.Service
{
    public class LoginAppService : ILoginAppService
    {

        private readonly ILoginAppService _login;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginAppService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                model.ValidationResult = new ValidationResult();
                model.ValidationResult.Info = "Usuário logado com sucesso.";
                return true;
            }
            else
            {
                model.ValidationResult = new ValidationResult();
                model.ValidationResult.Info = "Login ou senha incorretos.";
                return false;
            }

        }

        public bool LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
