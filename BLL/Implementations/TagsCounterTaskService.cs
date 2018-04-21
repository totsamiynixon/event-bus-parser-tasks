using AutoMapper;
using BLL.DTO.TagsCounterDTO;
using BLL.Interfaces;
using DAL.Data;
using IFL.Messages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;
using Web.Models.Domain;

namespace BLL.Implementations
{
    public class TagsCounterTaskService : ITagsCounterTaskService
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<TagsCounterTask> _taskRepository;
        private readonly ITinyMessengerHub _messengerHub;
        public TagsCounterTaskService(ApplicationDbContext db, ITinyMessengerHub messengerHub)
        {
            _db = db;
            _messengerHub = messengerHub;
            _taskRepository = db.Set<TagsCounterTask>();
        }
        public async Task<string> AddAsync(string url)
        {
            var trackingCode = Guid.NewGuid().ToString();
            var task = new TagsCounterTask
            {
                Status = TagsCounterTaskStatus.Started,
                TrackingCode = trackingCode,
                Url = url
            };
            _taskRepository.Add(task);
            await _db.SaveChangesAsync();
            _messengerHub.PublishAsync(new TaskCreatedMessage(this, task.Id, task.Url));
            return trackingCode;
        }

        public async Task<CompletionInfoDTO> GetCompletionStateAsync(string trackingCode)
        {
            var task = await _taskRepository.FirstOrDefaultAsync(f => f.TrackingCode == trackingCode);
            if (task == null)
            {
                return null;
            }
            return Mapper.Map<TagsCounterTask, CompletionInfoDTO>(task);
        }
    }
}
