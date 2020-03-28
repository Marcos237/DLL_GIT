using AutoMapper;
using Dll.Application.Model;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.AutoMapper
{
    public  class EntityToViewModelMapper:Profile
    {
        public EntityToViewModelMapper()
        {
            CreateMap<Log, LogViewModel>();
        }
    }
}
