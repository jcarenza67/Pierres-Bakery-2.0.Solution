using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;
using System.Collections.Generic;
using System;

namespace PierresBakery.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("type", "description", "quantity", 19.99m, "date");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "description";
      Order newOrder = new Order("type", description, "quantity", 19.99m, "date");

      string result = newOrder.Description;

      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void GetId_ReturnsOrderId_Int()
    {
      Order newOrder = new Order("type", "description", "quantity", 19.99m, "date");

      int result = newOrder.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllOrderObjects_OrderList()
    {
      Order newOrder1 = new Order("type01", "description", "quantity", 19.99m, "date");
      Order newOrder2 = new Order("type02", "description", "quantity", 19.99m, "date");
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order()
    {
      Order newOrder1 = new Order("type01", "description", "quantity", 19.99m, "date");
      Order newOrder2 = new Order("type02", "description", "quantity", 19.99m, "date");

      Order result = Order.Find(2);

      Assert.AreEqual(newOrder2, result);  
    }

    [TestMethod]
    public void GetPrice_ReturnsPrice_Decimal()
    {
      decimal price = 19.99m;
      Order newOrder = new Order("type", "description", "quantity", 19.99m, "date");

      decimal result = newOrder.Price;

      Assert.AreEqual(price, result);
    }
  }
}