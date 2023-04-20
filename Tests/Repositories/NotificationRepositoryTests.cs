using System;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests.Repositories
{
    //public class NotificationRepositoryTests
    //{
    //    private ApplicationDbContext _context;
    //    private INotificationRepository _repository;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //            .UseInMemoryDatabase(databaseName: "NotificationDatabase")
    //        .Options;

    //        _context = new ApplicationDbContext(options);
    //        _repository = new EmailNotificationRepository(_context);
    //    }

    //    [Test]
    //    public async Task AddNotificationAsync_ShouldAddNotificationToDatabase()
    //    {
    //        // Arrange
    //        var notification = new EmailNotification
    //        {
    //            Type = "Email",
    //            Recipient = "test@example.com",
    //            Content = "This is a test email notification.",
    //            ScheduledTime = DateTime.UtcNow.AddMinutes(1),
    //            IsSent = false,
    //            RetryCount = 0
    //        };

    //        // Act
    //        await _repository.AddNotificationAsync(notification);

    //        // Assert
    //        Assert.That(await _context.EmailNotifications.CountAsync(), Is.EqualTo(1));
    //        Assert.That(await _context.EmailNotifications.FirstAsync(), Is.EqualTo(notification));
    //    }
    //}

    //[TestFixture]
    //public class NotificationRepositoryTests
    //{
    //    private INotificationRepository _notificationRepository;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //            .UseInMemoryDatabase(databaseName: "test_database")
    //            .Options;

    //        var dbContext = new ApplicationDbContext(options);

    //        _notificationRepository = new NotificationRepository(dbContext);
    //    }

    //    [Test]
    //    public async Task GetNotificationsAsync_ReturnsAllNotifications()
    //    {
    //        // Arrange
    //        var notifications = new List<INotification>
    //    {
    //        new EmailNotification(),
    //        new SmsNotification(),
    //        new EmailNotification(),
    //    };
    //        await AddNotificationsAsync(notifications);

    //        // Act
    //        var result = await _notificationRepository.GetNotificationsAsync();

    //        // Assert
    //        Assert.AreEqual(notifications.Count, result.Count());
    //    }

    //    [Test]
    //    public async Task GetNotificationByIdAsync_ReturnsCorrectNotification()
    //    {
    //        // Arrange
    //        var notifications = new List<INotification>
    //    {
    //        new EmailNotification(),
    //        new SmsNotification(),
    //        new EmailNotification(),
    //    };
    //        await AddNotificationsAsync(notifications);
    //        var notificationToFind = notifications.First();

    //        // Act
    //        var result = await _notificationRepository.GetNotificationByIdAsync(notificationToFind.Id);

    //        // Assert
    //        Assert.AreEqual(notificationToFind.Id, result.Id);
    //    }

    //    [Test]
    //    public async Task AddNotificationAsync_AddsNotificationToDatabase()
    //    {
    //        // Arrange
    //        var notificationToAdd = new EmailNotification();

    //        // Act
    //        await _notificationRepository.AddNotificationAsync(notificationToAdd);
    //        var result = await _notificationRepository.NotificationExistsAsync(notificationToAdd.Id);

    //        // Assert
    //        Assert.IsTrue(result);
    //    }

    //    [Test]
    //    public async Task UpdateNotificationAsync_UpdatesExistingNotification()
    //    {
    //        // Arrange
    //        var notifications = new List<INotification>
    //    {
    //        new EmailNotification(),
    //        new SmsNotification(),
    //        new EmailNotification(),
    //    };
    //        await AddNotificationsAsync(notifications);
    //        var notificationToUpdate = notifications.First();
    //        notificationToUpdate.Status = NotificationStatus.Sent;

    //        // Act
    //        await _notificationRepository.UpdateNotificationAsync(notificationToUpdate);
    //        var result = await _notificationRepository.GetNotificationByIdAsync(notificationToUpdate.Id);

    //        // Assert
    //        Assert.AreEqual(NotificationStatus.Sent, result.Status);
    //    }

    //    [Test]
    //    public async Task NotificationExistsAsync_ReturnsTrueIfNotificationExists()
    //    {
    //        // Arrange
    //        var notificationToAdd = new EmailNotification();
    //        await _notificationRepository.AddNotificationAsync(notificationToAdd);

    //        // Act
    //        var result = await _notificationRepository.NotificationExistsAsync(notificationToAdd.Id);

    //        // Assert
    //        Assert.IsTrue(result);
    //    }

    //    private async Task AddNotificationsAsync(IEnumerable<INotification> notifications)
    //    {
    //        foreach (var notification in notifications)
    //        {
    //            await _notificationRepository.AddNotificationAsync(notification);
    //        }
    //    }
    //}


}

