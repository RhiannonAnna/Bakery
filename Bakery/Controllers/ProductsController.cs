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
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Route(""), HttpGet]
        public List<Product> GetAllProducts()
        {
            return MainService.GetAllProducts();
        }

        [Route("{ID}"), HttpGet]
        public Product GetSingleProduct([FromRoute] int ID)
        {
            return MainService.GetProduct(ID);
        }

        [Route(""), HttpPost]
        public IActionResult InsertProduct([FromBody] Product product)
        {
            try
            {
                MainService.InsertProduct(product);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        

        [Route(""), HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                MainService.UpdateProduct(product);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
        [Route("{ID}"), HttpDelete]
        public IActionResult DeleteProduct([FromRoute] int ID)
        {
            try
            {
                MainService.DeleteProduct(ID);
                return Ok();
            }
            catch (Exception exc)
            {
                return new ObjectResult(exc) { StatusCode = 500 };
            }
        }
    }
}