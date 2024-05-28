using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogWeb.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    ViewData.Clear(); // ViewData'yı temizle
        //    base.OnActionExecuted(context);
        //}
    }
}
