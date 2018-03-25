using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models.Domain
{
    public class TagsCounterTask
    {
        public int Id { get; set; }

        public string TrackingCode { get; set; }

        public string Url { get; set; }

        public TagsCounterTaskStatus Status { get; set; }

        public string Result { get; set; }
    }
}