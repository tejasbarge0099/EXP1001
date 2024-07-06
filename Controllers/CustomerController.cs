using EXP1001.Models;
using EXP1001.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EXP1001.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerRepo _cust;
        public readonly IBookingRepo _book;
        public CustomerController(ICustomerRepo cust, IBookingRepo book)
        {
            _cust = cust;
            _book = book;
        }

        [HttpPost("Add")]
        public IActionResult Add(CustomerModel f)
        {
            _cust.AddCustomer(f);
            return Ok("Success");
        }

        [HttpPost("AddBulk")]
        public IActionResult AddBulk(List<CustomerModel> f)
        {
            _cust.AddBulkCustomers(f);
            return Ok("Success");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<CustomerModel> l = _cust.GetAllCustomers();
            return Ok(l);
        }

        [HttpGet("GetWithId")]
        public IActionResult GetWithId(int id)
        {
            CustomerModel l = _cust.GetCustomerByID(id);
            return Ok(l);
        }

        [HttpGet("GetWithBg")]
        public IActionResult GetWithBg(string s)
        {
            List<CustomerModel> l = _cust.GetCutomersByBloodGroup(s);
            return Ok(l);
        }
        
        [HttpPatch("UpdateCustomer")]
        public IActionResult UpdateCustomer(int id, JsonPatchDocument j)
        {
            _cust.UpdateCustomer(id, j);
            return Ok("Success");
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            _cust.RemoveCustomerById(_book.GetAllBookings(),id);
            return Ok("Success");
        }
    }
}