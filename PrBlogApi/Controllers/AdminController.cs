using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrBlogApi.Models.Entity;
using PrBlogApi.Models.Helper;

namespace PrBlogApi.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Login()
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                Admin admin = db.Admin.FirstOrDefault();

                return Request.CreateResponse(HttpStatusCode.OK, admin.Password);
            }
            catch (Exception ex)
            {
                string msg = "A problem caused during login as admin. Exception message : " + ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, msg);
            }
        }
        [HttpPost]
        public string ChangePassword(AdminPasswordChange entity)
        {
            try
            {
                BlogForPrContext db = new BlogForPrContext();
                Admin tempAdmin = db.Admin.FirstOrDefault();

                int result = 0;

                if (tempAdmin.Password == entity.OldPassword)
                {
                    tempAdmin.Password = entity.NewPassword;
                    result = db.SaveChanges();
                }

                return result == 1 ? "Password updated!" : "Old password is incorrect.";

            }
            catch (Exception ex)
            {
                string msg = "A problem caused during changing password as admin. Exception message : " + ex.Message;
                return msg;
            }
        }
    }
}
