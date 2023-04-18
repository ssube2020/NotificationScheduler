using System;
using System.ComponentModel.DataAnnotations;
using Core.Interfaces;

namespace Core.Entities
{
    public class SmsNotification : INotification
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string Content { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsSent { get; set; }
        public int RetryCount { get; set; }

        public string Sender { get; set; }
    }
}

