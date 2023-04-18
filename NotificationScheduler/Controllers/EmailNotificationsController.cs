using System;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NotificationScheduler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailNotificationsController
    {
        private readonly ApplicationDbContext _context;

        public EmailNotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        

    }
}

