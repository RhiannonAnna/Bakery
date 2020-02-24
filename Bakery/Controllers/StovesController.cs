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
    [Route("api/stoves")]
    [ApiController]
    public class StovesController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<Stove> GetAllStoves()
        {
            return MainService.GetAllStoves();
        }

        [Route("{ID}"), HttpGet]
        public Stove GetSingleStove([FromRoute] int ID)
        {
            return MainService.GetStove(ID);
        }

        [Route(""), HttpPost]
        public IActionResult InsertStove([FromBody] Stove stove)
        {
            try
            {
                MainService.InsertStove(stove);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        

        [Route(""), HttpPut]
        public IActionResult UpdateStove([FromBody] Stove stove)
        {
            try
            {
                MainService.UpdateStove(stove);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteStove([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteStove(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
    }
}
