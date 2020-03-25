using Dll.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Application.Service
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
