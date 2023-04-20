using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace NotificationScheduler.Application.Services
{
    public class EmailNotificationService
    {
        private readonly EmailNotificationRepository _repository;

        public EmailNotificationService(EmailNotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultOfExecution<IEnumerable<INotification>>> GetNotificationsAsync()
        {
            return await _repository.GetNotificationsAsync();
        }

        public async Task<ResultOfExecution<INotification>> GetNotificationByIdAsync(int id)
        {
            return await _repository.GetNotificationByIdAsync(id);
        }

        public async Task<ResultOfExecution<INotification>> AddNotificationAsync(EmailNotification notification)
        {
            return await _repository.AddNotificationAsync(notification);
        }

        public async Task<ResultOfExecution<INotification>> UpdateNotificationAsync(EmailNotification notification)
        {
            return await _repository.UpdateNotificationAsync(notification);
        }

        public async Task<bool> NotificationExistsAsync(int id)
        {
            return await _repository.NotificationExistsAsync(id);
        }
    }
}
