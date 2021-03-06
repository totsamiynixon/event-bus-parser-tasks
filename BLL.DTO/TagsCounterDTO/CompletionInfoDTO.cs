﻿using BLL.DTO.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models.Domain;

namespace BLL.DTO.TagsCounterDTO
{
    public class CompletionInfoDTO
    {
        public TagsCounterTaskStatus Status { get; set; }

        public List<TagNameCountProjection> Result { get; set; }
    }
}
