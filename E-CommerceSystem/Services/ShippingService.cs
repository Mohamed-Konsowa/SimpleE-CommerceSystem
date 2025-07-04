using E_CommerceSystem.Entities;

namespace E_CommerceSystem.Services
{
	internal static class ShippingService
	{
		public static double Ship(List<ShippableItem> items)
		{
			double totalWeight = 0;

			Console.WriteLine();
			Console.WriteLine("** Shipment notice **");
			foreach (var item in items)
			{
				Console.WriteLine($"{item.quantity}x {item.GetName()}      {item.GetWeight()}g");
				totalWeight += item.GetWeight();
			}
			Console.WriteLine($"Total package weight {totalWeight / 1000}kg");
			return .5f * (totalWeight / 1000);

		}
	}
}
