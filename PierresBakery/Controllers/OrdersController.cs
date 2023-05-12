using PierresBakery.Models;
using Microsoft.AspNetCore.Mvc;

namespace PierresBakery.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}