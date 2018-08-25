using AutoMapper;
using BLL.DTO.Projections;
using BLL.DTO.TagsCounterDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models.Domain;

namespace IFL.Mapping
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<TagsCounterTask, CompletionInfoDTO>()
                .ForMember(f => f.Result, m => m.ResolveUsing(s => s.Status == TagsCounterTaskStatus.Completed ? JsonConvert.DeserializeObject<List<TagNameCountProjection>>(s.Result) : null));
        }
    }
}
