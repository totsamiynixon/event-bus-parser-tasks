using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessenger;

namespace IFL.Messages
{
    public class TaskCreatedMessage : TinyMessageBase
    {
        public int TaskId { get; }
        public TaskCreatedMessage(object sender, int taskId) : base(sender)
        {
            TaskId = taskId;
        }
    }
}
