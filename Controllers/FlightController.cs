using EXP1001.Models;
using EXP1001.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EXP1001.Controllers
{
    [Route("flight")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public readonly IFlightRepo _flight;
        public readonly IBookingRepo _book;
        public FlightController(IFlightRepo flight, IBookingRepo book)
        {
            _flight = flight;
            _book = book;
        }

        [HttpPost("Add")]
        public IActionResult Add(FlightModel f)
        {
            _flight.AddFlight(f);
            return Ok("Success");
        }

        [HttpPost("AddBulk")]
        public IActionResult AddBulk(List<FlightModel> f)
        {
            _flight.AddBulkFlights(f);
            return Ok("Success");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<FlightModel> l = _flight.GetAllFlights();
            return Ok(l);
        }

        [HttpGet("GetWithId")]
        public IActionResult GetWithId(int id)
        {
            FlightModel l = _flight.GetFlightWithID(id);
            return Ok(l);
        }

        [HttpGet("GetWithSource")]
        public IActionResult GetWithSource(string s)
        {
            List<FlightModel> l = _flight.GetFlightsWithSource(s);
            return Ok(l);
        }

        [HttpGet("GetRemCap")]
        public IActionResult GetRemCap(int id)
        {
            long l = _flight.GetRemainingCapacity(id);
            return Ok(l);
        }

        [HttpPatch("UpdateFlight")]
        public IActionResult UpdateFlight(int id, JsonPatchDocument j)
        {
            _flight.UpdateFlight(id, j);
            return Ok("Success");
        }

        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            _flight.RemoveFlightById(_book.GetAllBookings(), id);
            return Ok("Success");
        }
    }
}
