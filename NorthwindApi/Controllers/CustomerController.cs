using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NorthwindApi.Models;

namespace NorthwindApi.Controllers
{
    public class CustomerController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public IHttpActionResult GetCustomers()
        {
            return Ok(db.Customers.ToList());
        }

        public HttpResponseMessage GetCustomers(string id)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
            if (customer != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, customer);
                return response;
            }
            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Üzgünüz Müşteri Bulunamadı ");
                return errorResponse;
            }


        }
    }
}
