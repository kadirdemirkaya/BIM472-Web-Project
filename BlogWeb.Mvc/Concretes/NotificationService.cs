using BlogWeb.Mvc.Models.Enums;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BlogWeb.Mvc.Concretes
{
    public class NotificationService(IHttpContextAccessor _httpContextAccessor, ITempDataDictionaryFactory _tempDataDictionaryFactory)
    {

        public void CreateSuccessfullyNotification(string message)
        {
            var TempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);

            TempData["message"] = $"{Notification.successfully}|{message}";
        }

        public void CreateErrorNotification(string message)
        {
            var TempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);

            TempData["message"] = $"{Notification.error}|{message}";
        }

        public void SetTempData(string key, string value)
        {
            var tempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);
            tempData[key] = value;
        }

        public string GetTempData(string key)
        {
            var tempData = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);
            tempData.TryGetValue(key, out var value);
            return value as string;
        }
    }
}
