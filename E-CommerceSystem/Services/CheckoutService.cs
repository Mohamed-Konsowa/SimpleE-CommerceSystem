using E_CommerceSystem.Entities;
using E_CommerceSystem.Interfaces;
using E_CommerceSystem.Repositories;

namespace E_CommerceSystem.Services
{
	internal static class CheckoutService
	{
		public static void Checkout(CartRepository cart, ProductRepository productRepository)
		{
			float totalPrice = 0, totalWeight = 0;

			var customerItems = cart.GetCustomerItems();

			if (customerItems.Count == 0)
			{
				throw new Exception("Cart is empty!");
			}

			var shippableItems = new List<ShippableItem>();

			foreach (var item in customerItems)
			{
				var product = productRepository.Get(item.ProductId);
				var (isShippable, weight) = productRepository.IsProductShippable(item.ProductId);
				totalPrice += product.Price * item.Quantity;
				totalWeight += weight * item.Quantity;

				if (productRepository.IsProductExpired(item.ProductId))
				{
					throw new Exception($"{product.Name} is expired!");
				}

				if (isShippable)
				{
					shippableItems.Add(new ShippableItem(
						name: product.Name,
						weight: weight * item.Quantity,
						quantity: item.Quantity
					));
				}
			}

			double shippingFees = ShippingService.Ship(shippableItems);

			double paid = totalPrice + shippingFees;
			if (paid > cart.customer.Balance)
			{
				throw new Exception("Insufficient balance!");
			}

			cart.customer.Balance -= paid;
			cart.ClearCart();
			
			Console.WriteLine();
			Console.WriteLine("** Checkout receipt **");
			foreach (var item in customerItems)
			{
				var product = productRepository.Get(item.ProductId);
				Console.WriteLine($"{item.Quantity}x {product.Name}      {product.Price * item.Quantity}");
			}
			Console.WriteLine("----------------------");
			Console.WriteLine($"Subtotal    {totalPrice}");
			Console.WriteLine($"Shipping    {shippingFees}");
			Console.WriteLine($"Amount      {totalPrice + shippingFees}");
			Console.WriteLine($"Balance after payment  {cart.customer.Balance}");
		}
	}
}
