//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrBlogApi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Posts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Text { get; set; }
        public Nullable<System.DateTime> DatetimeOfCreated { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
        public virtual Categories Categories { get; set; }
    }
}
