namespace EXP1001.Models
{
    public class CustomerModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public long no { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string bg { get; set; }
        public string passport { get; set; }

        public CustomerModel(int id, string name, string address, long no, int age, string gender, string bg, string passport) 
        {
            this.id = id; 
            this.name = name;
            this.address = address;
            this.no = no;
            this.age = age;
            this.gender = gender;
            this.bg = bg;
            this.passport = passport;
        }


    }
}
