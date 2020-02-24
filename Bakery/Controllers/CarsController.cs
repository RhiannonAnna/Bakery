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
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<Car> GetAllCars()
        {
            return MainService.GetAllCars();
        }

        [Route("{ID}"), HttpGet]
        public Car GetSingleCar([FromRoute] int ID)
        {
            return MainService.GetCar(ID);
        }

        [Route(""), HttpPost]
        public IActionResult InsertCar([FromBody] Car car)
        {
            try
            {
                MainService.InsertCar(car);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }


        [Route(""), HttpPut]
        public IActionResult UpdateCar([FromBody] Car car)
        {
            try
            {
                MainService.UpdateCar(car);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteCar([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteCar(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
    }
}
