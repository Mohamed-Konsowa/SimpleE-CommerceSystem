using E_CommerceSystem.Entities;

namespace E_CommerceSystem.Repositories
{
	internal class ProductRepository
	{
		List<Product> products;
        List<ExpirationDate> expirationDates;
        List<Shipping> shippings; 
        public ProductRepository()
        {
            products = new List<Product>();
            expirationDates = new List<ExpirationDate>();
            shippings = new List<Shipping>();
        }
        public void Add(Product product, DateOnly? expirationDate = null, float? weight = null)
        {
            products.Add(product);

            if(expirationDate != null)
            {
                expirationDates.Add(new ExpirationDate
                {
                    ProductId = product.Id,
                    Date = (DateOnly)expirationDate
				});
			}

            if(weight != null)
            {
                shippings.Add(new Shipping
                {
                    ProductId= product.Id,
                    Weight = (float)weight
                });
            }
        }
        public Product? Get(int ProductId)
        {
            foreach(var p in products)
            {
                if(p.Id == ProductId) return p;
            }
            return null;
        }
		public bool IsProductExpired(int productId)
		{
			var today = DateOnly.FromDateTime(DateTime.Now);
			foreach (var ex in expirationDates)
			{
				if (ex.ProductId == productId && ex.Date <= today)
				{
					return true;
				}
			}
			return false;
		}

		public (bool, float) IsProductShippable(int productId)
		{
			foreach (var ex in shippings)
			{
				if (ex.ProductId == productId)
				{
					return (true, ex.Weight);
				}
			}
			return (false, 0);
		}
	}
}
