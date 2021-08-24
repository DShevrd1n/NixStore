namespace Web.Models
{
    public class OrderItemModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Articul { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
