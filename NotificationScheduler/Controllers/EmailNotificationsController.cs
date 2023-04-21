using System;
using Core.Common;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationScheduler.Application.Services;


namespace NotificationScheduler.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class EmailNotificationsController
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailNotificationService _emailService;

        public EmailNotificationsController(ApplicationDbContext context, EmailNotificationService service)
        {
            _emailService = service;
            _context = context;
        }

        [HttpGet]
        public async Task<ResultOfExecution<IEnumerable<INotification>>> GetNotifications()
        {
            return await _emailService.GetNotificationsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ResultOfExecution<INotification>> GetNotificationById(int id)
        {
            return await _emailService.GetNotificationByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<ResultOfExecution<INotification>>> AddNotification(EmailNotification notification)
        {
            return await _emailService.AddNotificationAsync(notification);
        }

        [HttpPut]
        public async Task<ActionResult<ResultOfExecution<INotification>>> UpdateNotification(EmailNotification notification)
        {
            return await _emailService.UpdateNotificationAsync(notification);
        }

        [HttpGet]
        public async Task<bool> ExistsNotification(int id)
        {
            return await _emailService.NotificationExistsAsync(id);
        }

    }
}

