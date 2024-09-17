namespace WebApplication15.Models
{
    public class Customers
    {
        private string customerId = "n/a";
        private string companyName = "n/a";
        private string contactName = "n/a";
        private string contactTitle = "n/a";
        private string address = "n/a";
        private string city = "n/a";
        private string region = "n/a";
        private string postalCode = "n/a";
        private string country = "n/a";
        private string phone = "n/a";
        private string fax = "n/a";

        public string CustomerId
        {
            get { return this.customerId; }
            set { this.customerId = value; }
        }
        public string CompanyName
        {
            get { return this.companyName; }
            set { this.companyName = value; }
        }
        public string ContactName
        {
            get { return this.contactName; }
            set { this.contactName = value; }

        }
        public string ContactTitle
        {
            get { return this.contactTitle; }
            set { this.contactTitle = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }
        public string Region
        {
            get { return this.region; }
            set { this.region = value; }
        }
        public string PostalCode
        {
            get { return this.postalCode; }
            set { this.postalCode = value; }
        }
        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }
        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        public Customers() : this("n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a")
        {

        }

        public Customers(string aCustomerName) : this("n/a", aCustomerName, "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a")
        {

        }

        public Customers(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            CustomerId = customerId;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Fax = fax;
        }
        // ToString Method
        public override string ToString()
        {
            string message = "";
            message += "CustomerId: " + this.CustomerId + "<br/>";
            message += "CompanyName: " + this.CompanyName + "<br/>";
            message += "ContactName: " + this.ContactName + "<br/>";
            message += "ContactTitle: " + this.ContactTitle + "<br/>";
            message += "Address: " + this.Address + "<br/>";
            message += "City: " + this.City + "<br/>";
            message += "Region: " + this.Region + "<br/>";
            message += "PostalCode: " + this.PostalCode + "<br/>";
            message += "Country: " + this.Country + "<br/>";
            message += "Phone: " + this.Phone + "<br/>";
            message += "Fax: " + this.Fax + "<br/>";
            return message;
        }
    }
}