using System;
using Microsoft.Extensions.Hosting;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class NotificationSenderHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<NotificationSenderHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private Task _executingTask;

        public NotificationSenderHostedService(ILogger<NotificationSenderHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("NotificationSenderHostedService is starting.");

            _executingTask = Task.Run(async () => await ExecuteAsync(_cancellationTokenSource.Token));

            return Task.CompletedTask;
        }

        private async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking for scheduled notifications.");

                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

                    var scheduledEmailNotifications = await dbContext.EmailNotifications.Where(n => n.ScheduledTime <= DateTime.UtcNow && !n.IsSent).ToListAsync();
                    var scheduledSmslNotifications = await dbContext.SmsNotifications.Where(n => n.ScheduledTime <= DateTime.UtcNow && !n.IsSent).ToListAsync();

                    Parallel.ForEach(scheduledEmailNotifications, async notification =>
                    {
                        _logger.LogInformation($"Sending {notification.Type} notification to {notification.Recipient}.");

                        // Send the email notification using an appropriate service

                        notification.IsSent = true;
                    });

                    Parallel.ForEach(scheduledSmslNotifications, async notification =>
                    {
                        _logger.LogInformation($"Sending {notification.Type} notification to {notification.Recipient}.");

                        // Send the sms notification using an appropriate service

                        notification.IsSent = true;
                    });

                    await dbContext.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromSeconds(60), cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("NotificationSenderHostedService is stopping.");

            _cancellationTokenSource.Cancel();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }
    }

}

