namespace Orders.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
