using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;
using System.Collections.Generic;
using System;

namespace PierresBakery.Tests
{
  [TestClass]
    public class VendorTests : IDisposable
    {

      public void Dispose()
      {
        Vendor.ClearAll();
      }

      [TestMethod]
      public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
      {
        Vendor newVendor = new Vendor("test");
        Assert.AreEqual(typeof(Vendor), newVendor.GetType());
      }

      [TestMethod]
      public void GetName_ReturnsName_String()
      {
        string name = "Test Vendor";
        Vendor newVendor = new Vendor(name);

        string result = newVendor.Name;

        Assert.AreEqual(name, result);
      }

      [TestMethod]
      public void GetId_ReturnsVendorId_Int()
      {
        string name = "Test Vendor";
        Vendor newVendor = new Vendor(name);

        int result = newVendor.Id;

        Assert.AreEqual(1, result);
      }

      [TestMethod]
      public void GetAll_ReturnsAllVendorObjects_VendorList()
      {
        string name01 = "Gordoughs";
        string name02 = "Janets";
        Vendor newVendor1 = new Vendor(name01);
        Vendor newVendor2 = new Vendor(name02);
        List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

        List<Vendor> result = Vendor.GetAll();

        CollectionAssert.AreEqual(newList, result);
      }

      [TestMethod]
      public void Find_ReturnsCorrectVendor_Vendor()
      {
        string name01 = "Dannys";
        string name02 = "Baked Goods";
        Vendor newVendor1 = new Vendor(name01);
        Vendor newVendor2 = new Vendor(name02);

        Vendor result = Vendor.Find(2);

        Assert.AreEqual(newVendor2, result);
      }

      [TestMethod]
      public void AddOrder_AssociatesOrderWithVendor_OrderList()
      {
        string description = "Order description";
        Order newOrder = new Order(description);
        string vendorName = "Test Vendor";
        Vendor newVendor = new Vendor(vendorName);
        List<Order> newList = new List<Order> { newOrder };

        
        newVendor.AddOrder(newOrder);

        
        CollectionAssert.AreEqual(newList, newVendor.Orders);
      }
    }
}