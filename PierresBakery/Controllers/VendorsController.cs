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
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string description)
    {
      Vendor newVendor = new Vendor(vendorName, description);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(id);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("vendor", foundVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/create")]
    public ActionResult CreateOrder(int vendorId, string type, string description, string quantity, decimal price, string date)
    {
      
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(type, description, quantity, price, date);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;

      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", newOrder);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }
  }
}