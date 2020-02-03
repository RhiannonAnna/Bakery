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

namespace Bakery.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
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
        public int InsertEmployee([FromBody] Employee employee)
        {
            return MainService.InsertEmployee(employee);
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
