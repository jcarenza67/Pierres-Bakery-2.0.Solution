using PierresBakery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace PierresBakery.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View();
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName)
    {
      Vendor newVendor = new Vendor(vendorName);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Vendor foundVendor = Vendor.Find(id);
      return View(foundVendor);
    }
  }
}