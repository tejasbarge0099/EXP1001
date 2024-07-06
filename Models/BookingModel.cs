namespace EXP1001.Models
{
    public class BookingModel
    {
        public int BID { get; set; }
        public int CID { get; set; }
        public int FID { get; set; }
        public long Pass { get; set; }
        public DateTime BookDate { get; set; }
        public long BookCost { get; set; }

        public BookingModel(int BID, int CID, int FID, long Pass, DateTime BookDate, long BookCost)
        {
            this.BID = BID;
            this.CID = CID;
            this.FID = FID;
            this.Pass = Pass;
            this.BookDate = BookDate;
            this.BookCost = BookCost;
        }
    }
}
