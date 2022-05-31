using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NorthwindApi.Models;

namespace NorthwindApi.Controllers
{
    public class OrderController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public IHttpActionResult GetOrders()
        {
            return Ok(db.Orders.ToList());
        }
        public HttpResponseMessage GetOrders(int id)
        {
            Order orders = db.Orders.FirstOrDefault(x => x.OrderID == id);
            if (orders != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, orders);
                return response;
            }
            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Üzgünüz Sipariş Bulunamadı ");
                return errorResponse;
            }
        }
    }
}
