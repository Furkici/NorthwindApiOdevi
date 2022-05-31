using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NorthwindApi.Models;

namespace NorthwindApi.Controllers
{
    public class ProductController : ApiController
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public IHttpActionResult GetProducts()
        {
            return Ok(db.Products.ToList());
        }

        public HttpResponseMessage GetProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.ProductID == id);
            if (product != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, product);
                return response;
            }
            else
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Üzgünüz ürün bulunamadı ");
                return errorResponse;
            }


        }

        public IHttpActionResult PostProduct(Product product)
        {
            if (product != null)
            {
                db.Products.Add(product);
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }

        public HttpResponseMessage Put(Product product)
        {
            Product updated = db.Products.FirstOrDefault(x => x.ProductID == product.ProductID);

            if (updated == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ürün Bulunamadı");
            }
            else
            {
                updated.ProductName = product.ProductName;
                updated.UnitPrice = product.UnitPrice;
                return Request.CreateResponse(HttpStatusCode.OK, updated);
            }
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                db.Products.Remove(db.Products.FirstOrDefault(x => x.ProductID == id));
                return Ok("Veri Silindi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
