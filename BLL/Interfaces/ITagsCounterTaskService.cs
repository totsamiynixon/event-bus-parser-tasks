using BLL.DTO.TagsCounterDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITagsCounterTaskService
    {
        Task<string> AddAsync(string url);

        Task<CompletionInfoDTO> GetCompletionStateAsync(string trackingCode);
    }
}
