using Microsoft.AspNetCore.Mvc;
using Posta.Web.Models;
namespace Posta.Web.Controllers;
public sealed class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Error() { Response.StatusCode = 500; return View(new ErrorInfo(HttpContext.TraceIdentifier)); }
}
