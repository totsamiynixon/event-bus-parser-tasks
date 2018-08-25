using BLL.DTO.Projections;
using CsQuery;
using DAL.Data;
using IFL.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;
using Web.Models.Domain;
using Z.EntityFramework.Plus;

namespace IFL.EventBus
{
    public static class EventBusInitializer
    {
        public static void InitSubscribtions(ITinyMessengerHub hub)
        {
            hub.Subscribe<TaskCreatedMessage>(ProceedTask);
        }

        private static async void ProceedTask(TaskCreatedMessage message)
        {
            try
            {
                var tags = GetTagsCountProjection(message.Url);
                using (var context = new ApplicationDbContext())
                {
                    var repository = context.Set<TagsCounterTask>();
                    await repository.Where(f => f.Id == message.TaskId).UpdateAsync(f => new TagsCounterTask
                    {
                        Result = JsonConvert.SerializeObject(tags),
                        Status = TagsCounterTaskStatus.Completed
                    });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                using (var context = new ApplicationDbContext())
                {
                    var repository = context.Set<TagsCounterTask>();
                    await repository.Where(f => f.Id == message.TaskId).UpdateAsync(f => new TagsCounterTask
                    {
                        Status = TagsCounterTaskStatus.Failed
                    });
                    await context.SaveChangesAsync();
                }
            }
        }


        private static List<TagNameCountProjection> GetTagsCountProjection(string url)
        {
            var cq = CQ.CreateFromUrl(url);
            return cq.Document.QuerySelectorAll("*").GroupBy(f => f.NodeName).Select(f => new TagNameCountProjection
            {
                TagName = f.Key,
                Count = f.Count()
            }).ToList();
        }

    }
}
