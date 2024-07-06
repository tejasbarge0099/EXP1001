namespace EXP1001.Models
{
    public class FlightModel
    {
        public int Id { get; set; }
        public DateTime jrndate { get; set; }
        public string src { get; set; }
        public string destn { get; set; }
        public DateTime arrive { get; set; }
        public DateTime departure { get; set; }
        public long cost { get; set; }
        public long cap { get; set; }
        public long total { get; set; }

        public FlightModel(int id,string src, string destn, DateTime jrnDate, DateTime arrive, DateTime departure, long cost, long cap, long total)
        {
            this.Id = id;
            this.src = src;
            this.destn = destn;
            this.jrndate = jrnDate;
            this.arrive = arrive;
            this.departure = departure;
            this.cost = cost;
            this.cap = cap;
            this.total = total;
        }
    }
}
