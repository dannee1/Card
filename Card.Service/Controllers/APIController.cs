using Card.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Card.Service.Controllers
{
    public abstract class APIController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public APIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private Boolean Commit()
        {
            return _unitOfWork.Commit();
        }

    }
}
