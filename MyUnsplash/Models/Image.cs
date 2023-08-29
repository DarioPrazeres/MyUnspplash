using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyUnsplash.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        [Required]
        public string Label { get; set; }
        public string UrlFile { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}