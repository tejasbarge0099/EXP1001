using EXP1001.Models;
namespace EXP1001.Repo
{
    public interface IBookingRepo
    {
        public void AddBooking(List<FlightModel> f, BookingModel b);
        public void AddBulkBookings(List<FlightModel> f, List<BookingModel> b);
        public List<BookingModel> GetAllBookings();
        public List<BookingModel> GetBookingsWithDateRange(DateTime d1, DateTime d2);
        public long GetEarningsWithDateRange(DateTime d1, DateTime d2);
        public BookingModel GetBookingById(int id);
        public void RemoveBookingById(List<FlightModel> f, int id);
        public CustomerModel GetCustomerDetailsByBookingId(List<CustomerModel> f, int id);
        public List<FlightModel> GetAllFlightsWithSourceByBookingId(List<FlightModel> f, int id);
        public void AddPassangersToGivenBooking(List<FlightModel> f, int id, int p);
    }
    public class BookingRepo : IBookingRepo
    {
        List<BookingModel> l = new List<BookingModel>();
        public void AddBooking(List<FlightModel> f, BookingModel b)
        {
            foreach (FlightModel c in f)
            {
                if (c.Id == b.FID)
                {
                    if (c.cap - c.total > b.Pass)
                    {
                        l.Add(b);
                        c.total += b.Pass;
                    }
                }
            }
        }
        public void AddBulkBookings(List<FlightModel> f, List<BookingModel> b)
        {
            foreach (BookingModel m in b)
            {
                foreach (FlightModel c in f)
                {
                    if (c.Id == m.FID)
                    {
                        if (c.cap - c.total > m.Pass)
                        {
                            l.Add(m);
                            c.total += m.Pass;
                        }
                    }
                }
            }
        }
        public List<BookingModel> GetAllBookings()
        {
            return l;
        }
        public List<BookingModel> GetBookingsWithDateRange(DateTime d1, DateTime d2)
        {
            List<BookingModel> t = new List<BookingModel>();
            foreach (BookingModel c in l)
            {
                if (c.BookDate >= d1 && c.BookDate <= d2)
                    t.Add(c);
            }
            return t;
        }
        public long GetEarningsWithDateRange(DateTime d1, DateTime d2)
        {
            long ans = 0;
            foreach (BookingModel c in l)
            {
                if (c.BookDate >= d1 && c.BookDate <= d2)
                    ans += c.BookCost;
            }
            return ans;
        }
        public BookingModel GetBookingById(int id)
        {
            foreach (BookingModel c in l)
            {
                if (c.BID == id)
                    return c;
            }
            return null;
        }
        public void RemoveBookingById(List<FlightModel> f, int id)
        {
            for (int i = 0; i < l.Count; ++i)
            {
                if (l[i].BID == id)
                {
                    foreach (FlightModel c in f)
                    {
                        if (c.Id == l[i].FID)
                        {
                            c.total -= l[i].Pass;
                            l.Remove(l[i]);
                        }
                    }
                }
            }
        }
        public CustomerModel GetCustomerDetailsByBookingId(List<CustomerModel> c, int id)
        {
            foreach (BookingModel b in l)
            {
                if (b.BID == id)
                {
                    foreach (CustomerModel i in c)
                    {
                        if (i.id == b.CID)
                            return i;
                    }
                }
            }
            return null;
        }
        public List<FlightModel> GetAllFlightsWithSourceByBookingId(List<FlightModel> f, int id)
        {
            List<FlightModel> t = new List<FlightModel>();
            string s = "";
            foreach (BookingModel b in l)
            {
                if (b.BID == id)
                {
                    foreach (FlightModel i in f)
                    {
                        if (i.Id == b.FID)
                            s = i.src;
                    }
                    foreach (FlightModel i in f)
                    {
                        if (i.src.Equals(s))
                            t.Add(i);
                    }
                }
            }
            return t;
        }
        public void AddPassangersToGivenBooking(List<FlightModel> f, int id, int p)
        {
            for(int i=0; i<l.Count; ++i)
            {
                if (l[i].BID == id)
                {
                    foreach(FlightModel m in f)
                    {
                        if(m.Id == l[i].FID)
                        {
                            if(m.cap - m.total >= l[i].Pass + p)
                            {
                                l[i].Pass += p;
                                m.total += p;
                            }
                        }
                    }
                }
            }
        }


    }
}
