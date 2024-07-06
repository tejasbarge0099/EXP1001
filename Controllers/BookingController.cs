using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EXP1001.Repo;
using EXP1001.Models;

namespace EXP1001.Controllers
{
    [Route("booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly ICustomerRepo _cust;
        public readonly IBookingRepo _book;
        public readonly IFlightRepo _flight;
        public BookingController(ICustomerRepo cust, IFlightRepo flight, IBookingRepo book) 
        {   
            _cust = cust;
            _flight = flight;
            _book = book; 
        }

        [HttpPost("Add")]
        public IActionResult Add(BookingModel b)
        {
            _book.AddBooking(_flight.GetAllFlights(), b);
            return Ok("Success");
        }

        [HttpPost("AddBulk")]
        public IActionResult AddBulk(List<BookingModel> l)
        {
            _book.AddBulkBookings(_flight.GetAllFlights(), l);
            return Ok("Success");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<BookingModel> l = _book.GetAllBookings();
            return Ok(l);
        }

        [HttpGet("GetWithDateRange")]
        public IActionResult GetWithDateRange(List<DateTime> d)
        {
            List<BookingModel> l = _book.GetBookingsWithDateRange(d[0], d[1]);
            return Ok(l);
        }

        [HttpGet("GetEarnWithDateRange")]
        public IActionResult GetEarnWithDateRange(List<DateTime> d)
        {
            long l = _book.GetEarningsWithDateRange(d[0], d[1]);
            return Ok(l);
        }

        [HttpGet("GetWithId")]
        public IActionResult GetWithId(int id)
        {
            BookingModel l = _book.GetBookingById(id);
            return Ok(l);
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            _book.RemoveBookingById(_flight.GetAllFlights(), id);
            return Ok("Success");
        }

        [HttpGet("GetCustByBID")]
        public IActionResult GetCustByBID(int id)
        {
            CustomerModel c = _book.GetCustomerDetailsByBookingId(_cust.GetAllCustomers(), id);
            return Ok(c);
        }

        [HttpGet("GetFlightBySorceByBID")]
        public IActionResult GetFlightBySourceByBID(int id)
        {
            List<FlightModel> l = _book.GetAllFlightsWithSourceByBookingId(_flight.GetAllFlights(), id);
            return Ok(l);
        }

        [HttpPost("AddPass")]
        public IActionResult AddPass(int id, int p)
        {
            _book.AddPassangersToGivenBooking(_flight.GetAllFlights(), id, p);
            return Ok("Success");
        }   
    }
}
