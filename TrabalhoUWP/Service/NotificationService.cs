using System;
using System.Linq;
using Windows.UI.Notifications;

namespace TrabalhoUWP.Service
{
    public class NotificationService
    {
        public static void DeleteScheduledToastNotification(int toastId)
        {
            var notification = ToastNotificationManager.CreateToastNotifier()
                                    .GetScheduledToastNotifications().SingleOrDefault(n => n.Id == toastId.ToString());

            if (notification != null)
            {
                ToastNotificationManager.CreateToastNotifier().RemoveFromSchedule(notification);
            }
        }
    }
}
