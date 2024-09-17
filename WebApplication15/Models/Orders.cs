namespace WebApplication15.Models
{
    public class Orders
    {
        private int orderId = -1;
        private string customerId = "n/a";
        private int employeeId = -1;
        private string orderDate = "n/a";
        private string requiredDate = "n/a";
        private string shippedDate = "n/a";
        private int shipVia = -1;
        private decimal freight = Decimal.MaxValue;
        private string shipName = "n/a";
        private string shipAddress = "n/a";
        private string shipCity = "n/a";
        private string shipRegion = "n/a";
        private string shipPostalCode = "n/a";
        private string shipCountry = "n/a";

        public int OrderId
        {
            get { return this.orderId; }
            set { this.orderId = value; }
        }

        public string CustomerId
        {
            get { return this.customerId; }
            set { this.customerId = value; }
        }

        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
        }

        public string OrderDate
        {
            get { return this.orderDate; }
            set { this.orderDate = value; }
        }

        public string RequiredDate
        {
            get { return this.requiredDate; }
            set { this.requiredDate = value; }
        }

        public string ShippedDate
        {
            get { return this.shippedDate; }
            set { this.shippedDate = value; }
        }

        public int ShipVia
        {
            get { return this.shipVia; }
            set { this.shipVia = value; }
        }

        public decimal Freight
        {
            get { return this.freight; }
            set { this.freight = value; }
        }

        public string ShipName
        {
            get { return this.shipName; }
            set { this.shipName = value; }
        }

        public string ShipAddress
        {
            get { return this.shipAddress; }
            set { this.shipAddress = value; }
        }

        public string ShipCity
        {
            get { return this.shipCity; }
            set { this.shipCity = value; }
        }

        public string ShipRegion
        {
            get { return this.shipRegion; }
            set { this.shipRegion = value; }
        }

        public string ShipPostalCode
        {
            get { return this.shipPostalCode; }
            set { this.shipPostalCode = value; }
        }

        public string ShipCountry
        {
            get { return this.shipCountry; }
            set { this.shipCountry = value; }
        }

        // constructors
        public Orders() : this(-1, "n/a", -1, "n/a", "n/a", "n/a", -1, Decimal.MaxValue, "n/a", "n/a", "n/a", "n/a", "n/a", "n/a")
        {
            // Additional initialization can be done here if necessary
        }
        public Orders(string aShipName) : this(-1, "n/a", -1, "n/a", "n/a", "n/a", -1, Decimal.MaxValue, aShipName, "n/a", "n/a", "n/a", "n/a", "n/a")
        {
        }


        public Orders(int aOrderId, string aCustomerId, int aEmployeeId, string aOrderDate, string aRequiredDate, string aShippedDate, int aShipVia, decimal aFreight, string aShipName, string aShipAddress, string aShipCity, string aShipRegion, string aShipPostalCode, string aShipCountry)
        {
            this.OrderId = aOrderId;
            this.CustomerId = aCustomerId;
            this.EmployeeId = aEmployeeId;
            this.OrderDate = aOrderDate;
            this.RequiredDate = aRequiredDate;
            this.ShippedDate = aShippedDate;
            this.ShipVia = aShipVia;
            this.Freight = aFreight;
            this.ShipName = aShipName;
            this.ShipAddress = aShipAddress;
            this.ShipCity = aShipCity;
            this.ShipRegion = aShipRegion;
            this.ShipPostalCode = aShipPostalCode;
            this.ShipCountry = aShipCountry;
        }

        // ToString Method
        public override string ToString()
        {
            string message = "";
            message += "OrderId: " + this.OrderId + "<br/>";
            message += "CustomerId: " + this.CustomerId + "<br/>";
            message += "EmployeeId: " + this.EmployeeId + "<br/>";
            message += "OrderDate: " + this.OrderDate + "<br/>";
            message += "RequiredDate: " + this.RequiredDate + "<br/>";
            message += "ShippedDate: " + this.ShippedDate + "<br/>";
            message += "ShipVia: " + this.ShipVia + "<br/>";
            message += "Freight: " + this.Freight + "<br/>";
            message += "ShipName: " + this.ShipName + "<br/>";
            message += "ShipAddress: " + this.ShipAddress + "<br/>";
            message += "ShipCity: " + this.ShipCity + "<br/>";
            message += "ShipRegion: " + this.ShipRegion + "<br/>";
            message += "ShipPostalCode: " + this.ShipPostalCode + "<br/>";
            message += "ShipCountry: " + this.ShipCountry + "<br/>";
            return message;
        }
    }
}
