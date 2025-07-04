using E_CommerceSystem.Entities;
using E_CommerceSystem.Repositories;
using E_CommerceSystem.Services;

namespace E_CommerceSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ProductRepository productRepository = new();

			var TV = new Product(Id: 1, Name: "TV", Quantity: 5, Price: 100);
			var Cheese = new Product(Id: 2, Name: "Cheese", Quantity: 10, Price: 15);
			var scratchCard = new Product(Id: 3, Name: "Scratch card", Quantity: 1, Price: 20.5f);
			
			productRepository.Add(product: TV, weight: 10000f);
			productRepository.Add(product: Cheese, expirationDate: DateOnly.FromDateTime(DateTime.Now.AddDays(2)), weight: 250f);
			productRepository.Add(product: scratchCard, expirationDate: DateOnly.FromDateTime(DateTime.Now.AddDays(30)));
			
			var customer1 = new Customer(Id: 1, Name: "Mohamed", Balance: 300);

			var cart = new CartRepository(customer1, productRepository);
			Console.WriteLine(cart.Add(1, 1));
			Console.WriteLine(cart.Add(2, 5));
			Console.WriteLine(cart.Add(3, 1));
			

			try
			{
				CheckoutService.Checkout(cart, productRepository);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
