using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrBlogApi.Models.Entity;

namespace PrBlogApi.Controllers
{
    public class PostController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Posts()
        {
            try
            {
               BlogForPrContext db = new BlogForPrContext();
               var posts = db.Posts.Select(i => new
               {
                   i.Id,
                   i.Title,
                   i.Info,
                   i.Text,
                   i.DatetimeOfCreated,
                   CategoryName = i.Categories.CategoryName,
                   CategoryId = i.CategoryId
               }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, posts);
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during getting posts. Exception message : " + ex.Message;
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
        }

        //func overload

        [HttpGet]
        public HttpResponseMessage Posts(int id)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                var posts = db.Categories.Find(id).Posts.Select(i => new
                {
                    i.Id,
                    i.Title,
                    i.Info,
                    i.Text,
                    i.DatetimeOfCreated,
                    CategoryName = i.Categories.CategoryName,
                    CategoryId = i.CategoryId
                }).ToList();

                return Request.CreateResponse(HttpStatusCode.OK, posts);
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during getting posts by its category. Exception message : " + ex.Message;
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
        }

        [HttpPost]
        public string AddPost(Posts entity)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                entity.DatetimeOfCreated = DateTime.Now;

                db.Posts.Add(entity);
                int result = db.SaveChanges();

                return result == 1 ? "Added succesfuly!" : "Adding Failed!";
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during adding post. Exception message : " + ex.Message;
                return msg;
            }
        }

        [HttpPut]
        public string UpdatePost(Posts entity)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();

                var tempPost = db.Posts.Find(entity.Id);

                tempPost.Title = entity.Title;
                tempPost.Info = entity.Info;
                tempPost.Text = entity.Text;
                tempPost.CategoryId = entity.CategoryId;
                int result = db.SaveChanges();

                return result == 1 ? "Updated succesfuly!" : "Update Failed!";
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during updating post. Exception message : " + ex.Message;
                return msg;
            }
        }

        [HttpDelete]
        public string DeletePost(int id)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                var tempPost = db.Posts.Find(id);
                db.Posts.Remove(tempPost);
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
