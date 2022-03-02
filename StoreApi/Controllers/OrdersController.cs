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

        private readonly IOrdersBL _ordbl;

        private readonly ICustomersBL _custbl;

        public OrdersController(IOrdersBL ordbl, ICustomersBL custbl)
        {
            _ordbl = ordbl;
            _custbl = custbl;
        }

        
        [HttpPost("AddOrders")]
        public IActionResult AddOrders([FromBody] Orders p_ord)
        {
            try
            {
                Log.Information("User is Adding an Order");
                return Created("Success", _ordbl.AddOrders(p_ord));
            }
            catch (System.Exception)
            {
                Log.Information("Displaying bad request to User");
                return BadRequest();
            }

        }


        [HttpGet("GetOrdersHistory")]
        public IActionResult GetOrdersHistory(int p_ordCustID, string email, string pass)
        {
            Log.Information("User is entering Credentials.");
            if(_custbl.isAdmin(email,pass))
            {
                try
                {
                    Log.Information("Displaying the Get Orders History.");
                    return Ok(_ordbl.GetOrdersHistory(p_ordCustID));
                }
                catch (SqlException)
                {
                    Log.Information("Displaying Not Found to User.");
                    return NotFound();
                }
            }
            else
            {
                Log.Information("Displaying No access allowed 401 to User.");
                return StatusCode(401, "No access allowed for this User");
            }
        }

        [HttpGet("GetOrdersHistoryTargeted")]
        public IActionResult GetOrdersHistoryTargeted(int p_ordCustID, string email, string pass, string p_target)
        {
            List<Orders> _listStoreOrder = _ordbl.SearchCustomerStoreOrders(p_ordCustID);

            Log.Information("User is entering Credentials.");
            if(_custbl.isAdmin(email,pass))
            {
                if (p_target.Equals("OrderTotal"))
                {
                    return Ok(_listStoreOrder.OrderBy(o => o.OrderTotal).ToList());
                }
                else if (p_target.Equals("OrderDate"))
                {
                    return Ok(_listStoreOrder.OrderBy(o => o.OrderDate).ToList());
                }
                else if (p_target.Equals("OrderTotal.Desc"))
                {
                    return Ok(_listStoreOrder.OrderByDescending(o => o.OrderTotal).ToList());
                }
                else if (p_target.Equals("OrderDate.Desc"))
                {
                    return Ok(_listStoreOrder.OrderByDescending(o => o.OrderDate).ToList());
                }
                else
                {
                    return NotFound("Keywords to Use are 'OrderTotal' or 'OrderDate' - use OrderTotal.Desc/OrderDate.Desc to Format Descending ");
                }
            }
            else
            {
                Log.Information("Displaying Not Found.");
                return StatusCode(401, "No access allowed for this User");
            }
            
        }
        
        [HttpGet("GetDetailedOrderHistory")]
        public IActionResult GetOrderHistory(int p_ordID, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
            {
                try
                {   
                    Log.Information("Displaying Order History to User.");
                    return Ok(_ordbl.GetOrderHistory(p_ordID));
                }
                catch (SqlException)
                {
                    Log.Information("Displaying Not Found to User.");
                    return NotFound();
                }
            }
            else
            {
                return StatusCode(401, "No access allowed for this User");
            }
        }

        [HttpGet("GetOrderHistoryLocation")]
        public IActionResult GetOrderHistoryLocation(int p_storeID, string email, string pass)
        {
            if(_custbl.isAdmin(email,pass))
            {
                try
                {   Log.Information("Displaying Search Store History to User.");
                    return Ok(_ordbl.SearchCustomerStoreOrders(p_storeID));
                }
                catch (SqlException)
                {
                    Log.Information("Displaying Not Found to User.");
                    return NotFound();
                }
            }
            else
            {   
                Log.Information("Displaying No Access Allowed for this User.");
                return StatusCode(401, "No access allowed for this User");
            }


        }
    
    }
}
