using E_CommerceSystem.Interfaces;

namespace E_CommerceSystem.Entities
{
	internal class ShippableItem : IShippable
	{
		string name;
		double weight;
		public int quantity;
		public ShippableItem(string name, double weight, int quantity)
		{
			this.name = name;
			this.weight = weight;
			this.quantity = quantity;
		}

		public string GetName() => name;
		public double GetWeight() => weight;
	}
}
