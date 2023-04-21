using System;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Net.NetworkInformation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationScheduler.Application.Services;
using NotificationScheduler.Controllers;
using Infrastructure.Repositories;

namespace Tests.EndpointTests
{
    [TestFixture]
    public class EmailNotificationsControllerTests
    {
        private ApplicationDbContext _dbContext;
        private EmailNotificationService _emailService;
        private EmailNotificationsController _controller;
        private EmailNotificationRepository _repo;

        [TestInitialize]
        public void Initialize()
        {
            _dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options);
            _emailService = new EmailNotificationService(_repo);

            _controller = new EmailNotificationsController(_dbContext, _emailService);
        }

        [TestMethod]
        public async Task GetNotifications_Returns_Notifications()
        {
            // Arrange
            var notification = new EmailNotification
            {
                Type = "Test",
                Recipient = "test@example.com",
                Content = "This is a test email",
                ScheduledTime = DateTime.UtcNow,
                IsSent = false,
                RetryCount = 0,
                Subject = "Test Email",
                Sender = "test-sender@example.com"
            };
            await _dbContext.EmailNotifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();

            var result = await _controller.GetNotifications();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task GetNotificationById_Returns_Notification()
        {
            var notification = new EmailNotification
            {
                Type = "Test",
                Recipient = "test@example.com",
                Content = "This is a test email",
                ScheduledTime = DateTime.UtcNow,
                IsSent = false,
                RetryCount = 0,
                Subject = "Test Email",
                Sender = "test-sender@example.com"
            };
            await _dbContext.EmailNotifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();

            var result = await _controller.GetNotificationById(notification.Id);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public async Task UpdateNotification_Updates_Notification()
        {
            var notification = new EmailNotification
            {
                Type = "Test",
                Recipient = "test@example.com",
                Content = "This is a test email",
                ScheduledTime = DateTime.UtcNow,
                IsSent = false,
                RetryCount = 0,
                Subject = "Test Email",
                Sender = "test-sender@example.com"
            };
            await _dbContext.EmailNotifications.AddAsync(notification);
            await _dbContext.SaveChangesAsync();

            notification.Content = "Updated content";

            var result = await _controller.UpdateNotification(notification);


        }

    }

}

