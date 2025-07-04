namespace E_CommerceSystem.Entities
{
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public Customer(int Id, string Name, double Balance)
        {
            this.Id = Id;
            this.Name = Name;
            this.Balance = Math.Max(Balance, 0);
        }
    }
}
