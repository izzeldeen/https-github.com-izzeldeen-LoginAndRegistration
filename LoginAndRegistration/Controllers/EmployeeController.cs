using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dto;
using Services.IServices;

namespace LoginAndRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddEmployee")]
        public ActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid) return Unauthorized();
           _unitOfWork.Employee.Add(employee);
           _unitOfWork.Save();
           return Ok(employee);
        }

        public IActionResult GetEmployee() => Ok(_unitOfWork.Employee.GetAll());

    }
}
