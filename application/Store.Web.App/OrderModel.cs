using ProdStore;


namespace Store.Web.App
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string CellPhone { get; set; }
        public string Adress { get; set; }
        public string PaymentType { get; set; }
        public OrderItemModel[] Items { get; set; } = new OrderItemModel[0];
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
