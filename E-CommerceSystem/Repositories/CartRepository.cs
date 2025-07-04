using E_CommerceSystem.Entities;

namespace E_CommerceSystem.Repositories
{
    internal class CartRepository
    {
        static List<CartItem> items = new List<CartItem>();
		public Customer customer { get; set; }
        ProductRepository productRepository;
        public CartRepository(Customer customer, ProductRepository productRepository)
        {
            this.customer = customer;
            this.productRepository = productRepository;
        }
        public string Add(int ProductId, int Quantity)
        {
            var product = productRepository.Get(ProductId);

            if (product == null) 
                return "Product not found!";
            if (productRepository.IsProductExpired(ProductId))
                return "Product is expired!";
            if (product.Quantity < Quantity) 
                return "No enough quantity!";
            if (product.Price * Quantity > customer.Balance)
                return "Insufficient balance!";

            var item = Get(ProductId, customer.Id);
            if(item != null)
            {
                item.Quantity += Quantity;
			}
            else
            {
				items.Add(new CartItem
				{
					CustomerId = customer.Id,
					ProductId = ProductId,
					Quantity = Quantity
				});
			}
            product.Quantity -= Quantity;
            
            return "Product added to cart successfully.";
        }
        private CartItem? Get(int ProductId, int CustomerId)
        {
            foreach(var item in items)
            {
                if(item.CustomerId == CustomerId && item.ProductId == ProductId)
                    return item;
            }
            return null;
        }
        public List<CartItem> GetCustomerItems()
        {
            var products = new List<CartItem>();
            foreach (var item in items)
                if(item.CustomerId == customer.Id)
                    products.Add(item);
            return products;
        }
		public void ClearCart()
		{
			items.RemoveAll(i => i.CustomerId == customer.Id);
		}
	}
}
