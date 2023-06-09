﻿using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<SmsNotification> SmsNotifications { get; set; }
    }

}

