using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Api
{
    public class GetTagsParserTaskModel
    {
        [Required]
        public string TrackingCode { get; set; }
    }
}