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
    [Route("api/typeEmploymentContracts")]
    [ApiController]
    public class TypesEmploymentContractsController : ControllerBase
    {

            [Route(""), HttpGet]
            public List<TypeEmploymentContract> GetAllTypeEmploymentContract()
            {
                return MainService.GetAllTypeEmploymentContract();
            }

            [Route("{ID}"), HttpGet]
            public TypeEmploymentContract GetSingleTypeEmploymentContract([FromRoute] int ID)
            {
                return MainService.GetTypeEmploymentContract(ID);
            }

            [Route(""), HttpPost]
            public IActionResult InsertTypeEmploymentContract([FromBody] TypeEmploymentContract typeEmploymentContract)
            {
                try
                {
                    MainService.InsertTypeEmploymentContract(typeEmploymentContract);
                    return Ok();
                }
                catch (Exception exc)
                {
                    return new ObjectResult(exc) { StatusCode = 500 };
                }            
            }

            [Route(""), HttpPut]
            public IActionResult UpdateTypeEmploymentContract([FromBody] TypeEmploymentContract typeEmploymentContract)
            {
                try
                {
                    MainService.UpdateTypeEmploymentContract(typeEmploymentContract);
                    return Ok();
                }
                catch (Exception exc)
                {
                    return new ObjectResult(exc) { StatusCode = 500 };
                }
            }
            [Route("{ID}"), HttpDelete]
            public IActionResult DeleteTypeEmploymentContract([FromRoute] int ID)
            {
                try
                {
                    MainService.DeleteTypeEmploymentContract(ID);
                    return Ok();
                }
                catch (Exception exc)
                {
                    return new ObjectResult(exc) { StatusCode = 500 };
                }
            }
        }
    
}
