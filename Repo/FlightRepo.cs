using System.Runtime.Intrinsics.X86;
using EXP1001.Models;
using Microsoft.AspNetCore.JsonPatch;
namespace EXP1001.Repo
{
    public interface IFlightRepo
    {
        public void AddFlight(FlightModel f);
        public void AddBulkFlights(List<FlightModel> l);
        public List<FlightModel> GetAllFlights();
        public FlightModel GetFlightWithID(int id);
        public List<FlightModel> GetFlightsWithSource(string s);
        public long GetRemainingCapacity(int id);
        public void UpdateFlight(int id, JsonPatchDocument j);
        public void RemoveFlightById(List<BookingModel> b, int id);
    }
    public class FlightRepo : IFlightRepo
    {
        List<FlightModel> l;
        public FlightRepo()
        { 
            l = new List<FlightModel>(); 
        }

        public void AddFlight(FlightModel f)
        {
            l.Add(f);
        }
        public void AddBulkFlights(List<FlightModel> f)
        {
            foreach(FlightModel c in f)
                l.Add(c);
        }
        public List<FlightModel> GetAllFlights()
        { 
            return l; 
        }
        public FlightModel GetFlightWithID(int id)
        {
            foreach (FlightModel f in l)
            {
                if (f.Id == id)
                    return f;
            }
            return null;
        }
        public List<FlightModel> GetFlightsWithSource(string s)
        {
            List<FlightModel> t = new List<FlightModel>();
            foreach (FlightModel f in l)
            {
                if (f.src.Equals(s))
                    t.Add(f);
            }
            return t;
        }
        public long GetRemainingCapacity(int id)
        {
            foreach (FlightModel f in l)
            {
                if (f.Id == id)
                    return f.cap - f.total;
            }
            return -1;
        }
        public void UpdateFlight(int id, JsonPatchDocument j)
        {
            foreach (FlightModel f in l)
            {
                if (f.Id == id)
                    j.ApplyTo(f);
            }
        }
        public void RemoveFlightById(List<BookingModel> b, int id)
        {
            for (int i = 0; i < b.Count; ++i)
            {
                if (b[i].FID == id)
                    b.Remove(b[i]);
            }
            for (int i=0; i<l.Count; ++i)
            {
                if (l[i].Id == id)
                    l.Remove(l[i]);
            }
        }
    }
}
