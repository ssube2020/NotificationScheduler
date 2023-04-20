using System;
using Core.Common;
using Core.Entities;

namespace Core.Interfaces
{
	public interface INotificationRepository
	{
        Task<ResultOfExecution<IEnumerable<INotification>>> GetNotificationsAsync();
        Task<ResultOfExecution<INotification>> GetNotificationByIdAsync(int id);
        Task<ResultOfExecution<INotification>> AddNotificationAsync(INotification notification);
        Task<ResultOfExecution<INotification>> UpdateNotificationAsync(INotification notification);
        Task<bool> NotificationExistsAsync(int id);
    }
}

