using Dll.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Interfaces
{
    public interface ILog
    {
        void RegistrarLog(ValidationResult result, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager);
    }
}
