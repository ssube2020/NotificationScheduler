using System;
namespace Core.Interfaces
{
    public interface INotification
    {
        string Type { get; set; }
        string Recipient { get; set; }
        string Content { get; set; }
        DateTime ScheduledTime { get; set; }
        bool IsSent { get; set; }
        int RetryCount { get; set; }
    }
}

