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
    [Route("api/bakeryPoints")]
    [ApiController]
    public class BakeryPointsController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<BakeryPoint> GetAllBakeryPoint()
        {
            return MainService.GetAllBakeryPoint();
        }

        [Route("{ID}"), HttpGet]
        public BakeryPoint GetSingleBakeryPoint([FromRoute] int ID)
        {
            return MainService.GetBakeryPoint(ID);
        }

        [Route(""), HttpPost]
        public IActionResult InsertBakery([FromBody] BakeryPoint bakeryPoint)
        {
            try
            {
                MainService.InsertBakeryPoint(bakeryPoint);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }


        [Route(""), HttpPut]
        public IActionResult UpdateBakeryPoint([FromBody] BakeryPoint bakeryPoint)
        {
            try
            {
                MainService.UpdateBakeryPoint(bakeryPoint);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteBakeryPoint([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteBakeryPoint(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
    }
}