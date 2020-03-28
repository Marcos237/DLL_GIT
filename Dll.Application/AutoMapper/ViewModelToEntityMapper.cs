
using AutoMapper;
using Dll.Application.Model;
using Dll.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Dll.Application.AutoMapper
{
    public class ViewModelToEntityMapper : Profile
    {
        public ViewModelToEntityMapper()
        {
            CreateMap<LogViewModel, Log>();
        }
    }
}
