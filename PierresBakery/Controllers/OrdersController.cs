using System;
using System.Collections.Generic;
using PierresBakery.Models;
using Microsoft.AspNetCore.Mvc;

namespace PierresBakery.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(string type, string description, string quantity, int vendorId, decimal price, string date)
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order newOrder = new Order(type, description, quantity, price, date);
      vendor.AddOrder(newOrder);
      return RedirectToAction("Show", "Vendors", new { id = vendorId });
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }
  }
}