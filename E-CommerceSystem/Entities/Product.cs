namespace E_CommerceSystem.Entities
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public Product(int Id, string Name, float Price, int Quantity)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
    }
}
