using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrBlogApi.Models.Helper
{
    public class AdminPasswordChange
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}