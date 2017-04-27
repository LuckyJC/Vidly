using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            //removed the () from Mapper.Map<>() because we are not calling this method- using it as a delegate/reference to the method
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        //by convention, returning a Customer object to the client because customer will have an Id
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            //validate if the model is valid
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            //add customer object and save changes
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //add customer id to the customer Dto
            customerDto.Id = customer.Id;

            //need to return the Created method with the URI and actual object that was created
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        //can return either a customer or void here
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            //passing in customerDto and second argument customerInDb; existing object loaded in _context and needs to track changes to this object
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
