using Dll.Application.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Application.Interfaces
{
    public interface ILoginAppService
    {
        Task<bool> Login(LoginViewModel model);
        bool LogOut();
    }
}
