namespace WebApplication15.Models
{
    public class OrderDetails
    {
        private int orderId = -1;
        private int productId = -1;
        private double unitPrice = Double.MaxValue;
        private int quantity = -1;
        private int discount = -1;

        public int OrderId
        {
            get { return this.orderId; }
            set { this.orderId = value; }
        }
        public int ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }
        public double UnitPrice
        {
            get { return (double)this.unitPrice; }
            set { this.unitPrice = (double)value; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public int Discount
        {
            get { return this.discount; }
            set { this.discount = value; }
        }
        public OrderDetails() : this(-1, -1, double.MaxValue, -1, -1)
        {

        }

        public OrderDetails(int aOrderId) : this(-1, -1, Double.MaxValue, -1, -1)
        {

        }

        public OrderDetails(int orderId, int productId, double unitPrice, int quantity, int discount)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.UnitPrice = unitPrice;
            this.quantity = quantity;
            this.discount = discount;
        }

    }
}