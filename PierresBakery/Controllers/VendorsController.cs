using PierresBakery.Models;
using Microsoft.AspNetCore.Mvc;

namespace PierresBakery.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      return View();
    }
  }
}