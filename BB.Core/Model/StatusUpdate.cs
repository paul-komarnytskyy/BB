using System;

namespace BB.Core.Model
{
    public class StatusUpdate
    {
        public Guid OrderId { get; set; }

        public Status Status { get; set; }

        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }
    }
}
