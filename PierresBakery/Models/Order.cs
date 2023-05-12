using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Order
  {
    public string Type { get; set; }
    public int Id { get; }
    public string Description { get; set; }
    public string Quantity { get; set; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string type, string description, string quantity)
    {
      Type = type;
      Description = description;
      Quantity = quantity;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
