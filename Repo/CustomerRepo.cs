using EXP1001.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Runtime.Intrinsics.X86;
namespace EXP1001.Repo
{
    public interface ICustomerRepo
    {
        public void AddCustomer(CustomerModel c);
        public void AddBulkCustomers(List<CustomerModel> c);
        public List<CustomerModel> GetAllCustomers();
        public CustomerModel GetCustomerByID(int id);
        public List<CustomerModel> GetCutomersByBloodGroup(string s);
        public void RemoveCustomerById(List<BookingModel> b, int id);
        public void UpdateCustomer(int id, JsonPatchDocument j);
    }
    public class CustomerRepo : ICustomerRepo
    {
        List<CustomerModel> l;
        public CustomerRepo()
        {
            l = new List<CustomerModel>();
        }
        public void AddCustomer(CustomerModel c)
        {
            l.Add(c);
        }
        public void AddBulkCustomers(List<CustomerModel> c)
        {
            foreach(CustomerModel i in c)
                l.Add(i);
        }
        public List<CustomerModel> GetAllCustomers()
        { 
            return l; 
        }
        public CustomerModel GetCustomerByID(int id)
        {
            foreach (CustomerModel i in l)
            {
                if(i.id == id)
                    return i;
            }
            return null;
        }
        public List<CustomerModel> GetCutomersByBloodGroup(string s)
        {
            List<CustomerModel> t = new List<CustomerModel>();
            foreach (CustomerModel i in l)
            {
                if(i.bg.Equals(s))
                    t.Add(i);
            }
            return t;
        }
        public void RemoveCustomerById(List<BookingModel> b, int id)
        {
            for (int i = 0; i < b.Count; ++i)
            {
                if (b[i].CID == id)
                    b.Remove(b[i]);
            }
            for (int i = 0; i < l.Count; ++i)
            {
                if(l[i].id == id)
                    l.Remove(l[i]);
            }
                
        }
        public void UpdateCustomer(int id, JsonPatchDocument j)
        {
            foreach( CustomerModel i in l)
            {
                if(i.id == id)
                    j.ApplyTo(i);
            }
        }
    }
}
