namespace Lezita2.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
