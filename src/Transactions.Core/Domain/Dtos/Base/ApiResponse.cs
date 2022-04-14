using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Core.Domain.Dtos.Base
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse() { }
        public ApiResponse(bool success, T data, IList<NotificationsResponse> notifications)
        {
            Success = success;
            Data = data;
            Notifications = notifications;
        }

        public ApiResponse(bool success, T dados)
        {
            Success = success;
            Data = dados;
        }

        public ApiResponse(bool success, NotificationsResponse notifications = null)
        {
            Success = success;
            Notifications = new List<NotificationsResponse> { notifications };
        }

        public ApiResponse(bool sucesso, IList<NotificationsResponse> notifications = null)
        {
            Success = sucesso;
            Notifications = notifications;
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public IList<NotificationsResponse> Notifications { get; set; }
    }
}
