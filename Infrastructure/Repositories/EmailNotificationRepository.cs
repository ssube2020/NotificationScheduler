using System;
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmailNotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmailNotificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultOfExecution<IEnumerable<INotification>>> GetNotificationsAsync()
        {
            try
            {
                var data = await _dbContext.EmailNotifications.ToListAsync();
                return new ResultOfExecution<IEnumerable<INotification>>
                {
                    StatusCode = 200,
                    Message = "success",
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new ResultOfExecution<IEnumerable<INotification>>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = null
                };
            }

        }

        public async Task<ResultOfExecution<INotification>> GetNotificationByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.EmailNotifications.FindAsync(id);
                return new ResultOfExecution<INotification>
                {
                    StatusCode = 200,
                    Message = "success",
                    Data = result as EmailNotification
                };
            }
            catch (Exception ex)
            {
                return new ResultOfExecution<INotification>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = null
                };
            }

        }

        public async Task<ResultOfExecution<INotification>> AddNotificationAsync(INotification notification)
        {
            try
            {
                await _dbContext.EmailNotifications.AddAsync((EmailNotification)notification);
                await _dbContext.SaveChangesAsync();
                return new ResultOfExecution<INotification>
                {
                    StatusCode = 200,
                    Message = "success"
                };
            }
            catch(Exception ex)
            {
                return new ResultOfExecution<INotification>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = null
                };
            }
            
        }

        public async Task<ResultOfExecution<INotification>> UpdateNotificationAsync(INotification notification)
        {
            try
            {
                _dbContext.EmailNotifications.Update((EmailNotification)notification);
                await _dbContext.SaveChangesAsync();

                return new ResultOfExecution<INotification>
                {
                    StatusCode = 200,
                    Message = "success",
                    Data = (EmailNotification)notification
                };
            }
            catch (Exception ex)
            {
                return new ResultOfExecution<INotification>
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<bool> NotificationExistsAsync(int id)
        {
            return await _dbContext.EmailNotifications.AnyAsync(n => n.Id == id);
        }
    }

}

