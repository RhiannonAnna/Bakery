using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bakery.CodeBase.DataLayer;
using Bakery.Entities;
using Bakery.CodeBase.ServiceLayer;
using Microsoft.AspNetCore.Cors;

namespace Bakery.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<Employee> GetAllEmployee()
        {
            return MainService.GetAllEmployees();
        }

        [Route("{ID}"), HttpGet]
        public Employee GetSingleEmployee([FromRoute] int ID)
        {
            return MainService.GetEmployee(ID);
        }

        [Route(""), HttpPost]
        public IActionResult InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                MainService.InsertEmployee(employee);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        

        [Route(""), HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                MainService.UpdateEmployee(employee);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteEmployee([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteEmployee(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
    }
}
