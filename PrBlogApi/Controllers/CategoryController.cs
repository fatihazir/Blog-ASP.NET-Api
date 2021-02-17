using PrBlogApi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;

namespace PrBlogApi.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Categories()
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                var categories = db.Categories.Select(i => new
                {
                   i.Id,
                   i.CategoryName
                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during getting categories. Exception message : " + ex.Message;
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
        }

        [HttpPost]
        public string AddCategory(Categories entity)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();

                db.Categories.Add(entity);
                var result = db.SaveChanges();
               
                return result == 1 ? "Added succesfuly!" : "Adding Failed!";
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during adding category. Exception message : " + ex.Message;
                return msg;
            }
        }

        [HttpPut]
        public string UpdateCategory(Categories entity)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();

                var tempCat = db.Categories.Find(entity.Id);
                tempCat.CategoryName = entity.CategoryName;
                
                int result = db.SaveChanges();

                return result == 1 ? "Updated succesfuly!" : "Update Failed!";
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during updating category. Exception message : " + ex.Message;
                return msg;
            }
        }

        [HttpDelete]
        public string DeleteCategory(int id)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                var tempCat = db.Categories.Find(id);
                db.Categories.Remove(tempCat);
                int result = db.SaveChanges();

                return result == 1 ? "Deleted succesfuly!" : "Delete Failed!";
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during deleting category. Exception message : " + ex.Message;
                return msg;
            }
        }


    }
}
