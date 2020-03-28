using Dll.Application.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Interfaces
{
    public interface ILoginAppService
    {
        bool Login(LoginViewModel model);
        bool LogOut();
    }
}
