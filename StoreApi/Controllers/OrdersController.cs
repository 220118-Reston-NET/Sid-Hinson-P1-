using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModel;

namespace StoreApi.Controllers
{
    [Route("store-api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private IOrdersBL _ordbl;

        public OrdersController(IOrdersBL ordbl)
        {
            _ordbl = ordbl;
        }


        //POST AddOrders
        [HttpPost("AddOrders")]
        public IActionResult AddOrders([FromBody] Orders p_ord)
        {
            // try
            // {
                return Created("Success", _ordbl.AddOrders(p_ord));
            // }
            // catch (System.Exception)
            // {
            //     return BadRequest();
            // }

        }


        [HttpGet("GetOrdersHistory")]
        public IActionResult GetOrdersHistory(int p_ordCustID)
        {
            try
            {
                return Ok(_ordbl.GetOrdersHistory(p_ordCustID));
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }

        
        [HttpGet("GetOrderHistory")]
        public IActionResult GetOrderHistory(int p_ordID)
        {
            try
            {
                return Ok(_ordbl.GetOrderHistory(p_ordID));
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }


        // // POST: api/Orders
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT: api/Orders/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE: api/Orders/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
