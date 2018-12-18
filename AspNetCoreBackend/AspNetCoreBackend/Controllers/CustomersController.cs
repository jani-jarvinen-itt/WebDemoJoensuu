using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public List<Customers> GetAll()
        {
            NorthwindContext context = new NorthwindContext();
            List<Customers> asiakkaat = context.Customers.ToList();
            return asiakkaat;
        }

        [Route("{key}")]
        public Customers GetSingle(string key)
        {
            NorthwindContext context = new NorthwindContext();
            Customers asiakas = context.Customers.Find(key);
            return asiakas;
        }

        [HttpPost]
        public string PostCreateNew([FromBody] Customers customer)
        {
            NorthwindContext context = new NorthwindContext();
            context.Customers.Add(customer);
            context.SaveChanges();

            return customer.CustomerId;
        }

        [HttpPut]
        [Route("{key}")]
        public string PutEdit(string key, [FromBody] Customers newData)
        {
            NorthwindContext context = new NorthwindContext();
            Customers asiakas = context.Customers.Find(key);

            if (asiakas != null)
            {
                asiakas.CompanyName = newData.CompanyName;
                asiakas.ContactName = newData.ContactName;
                asiakas.ContactTitle = newData.ContactTitle;
                asiakas.Address = newData.Address;
                asiakas.Phone = newData.Phone;
                asiakas.Fax = newData.Fax;

                context.SaveChanges();
                return "OK";
            }

            return "NOT FOUND";
        }

        [HttpDelete]
        [Route("{key}")]
        public string DeleteSingle(string key)
        {
            NorthwindContext context = new NorthwindContext();
            Customers asiakas = context.Customers.Find(key);

            if (asiakas != null)
            {
                context.Customers.Remove(asiakas);
                context.SaveChanges();
                return "DELETED";
            }

            return "NOT FOUND";
        }
    }
}