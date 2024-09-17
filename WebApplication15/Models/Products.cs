namespace WebApplication15.Models
{
    public class Products
    {
        private int productId = -1;
        private string productName = "n/a";
        private int supplierId = -1;
        public int categoryId = -1;
        private double unitPrice = Double.MaxValue;

        public int ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }
        public string ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }
        public int SupplierId
        {
            get { return this.supplierId; }
            set { this.supplierId = value; }

        }
        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }
        public double UnitPrice
        {
            get { return (double)this.unitPrice; }
            set { this.unitPrice = (double)value; }
        }

        public Products() : this(-1, "n/a", -1, -1, double.MaxValue)
        {

        }

        public Products(string aproductname) : this(-1, aproductname, -1, -1, double.MaxValue)
        {

        }


        public Products(int productId, string productName, int supplierId, int categoryID, double unitPrice)
        {
            ProductId = productId;
            ProductName = productName;
            SupplierId = supplierId;
            CategoryId = categoryId;
            UnitPrice = unitPrice;

        }

        public override string ToString()
        {
            return $"Product Id:{ProductId}\n" +
                   $"Product Name:{ProductName}\n" +
                   $"Supplier Id: {SupplierId}\n" +
                   $"Category Id: {CategoryId}\n" +
                   $"Unit Price: {UnitPrice}\n";


        }
    }
}
