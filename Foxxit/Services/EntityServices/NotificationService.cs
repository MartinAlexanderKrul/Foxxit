﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;
using Foxxit.Services.EntityServices;

namespace Foxxit.Services
{
    public class NotificationService : GenericEntityService<Notification>, INotificationService
    {
        public NotificationService(NotificationRepository repository)
            : base(repository)
        {
        }

        public async Task MarkNotificationRead(Notification notification)
        {
            var dbNotification = await GetByIdAsync(notification.Id);
            dbNotification.HasBeenRead = true;
            Update(notification);
            await SaveAsync();
        }
    }
}