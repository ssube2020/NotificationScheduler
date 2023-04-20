using System;
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SmsNotificationRepository : INotificationRepository
    {
        public Task<ResultOfExecution<INotification>> AddNotificationAsync(INotification notification)
        {
            throw new NotImplementedException();
        }

        public Task<ResultOfExecution<INotification>> GetNotificationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultOfExecution<IEnumerable<INotification>>> GetNotificationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> NotificationExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultOfExecution<INotification>> UpdateNotificationAsync(INotification notification)
        {
            throw new NotImplementedException();
        }
    }

}

