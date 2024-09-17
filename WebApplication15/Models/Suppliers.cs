namespace WebApplication15.Models
{
    public class Suppliers
    {
        private int supplierId = -1;
        private string companyName = "n/a";
        private string contactTitle = "n/a";
        private string address = "n/a";
        private string city = "n/a";
        private string contactName = "n/a";
        private string postalCode = "n/a";
        private string country = "n/a";
        private string phone = "n/a";
        private string fax = "n/a";
        private string homePage = "n/a";

        public int SupplierId
        {
            get { return this.supplierId; }
            set { this.supplierId = value; }
        }
        public string CompanyName
        {
            get { return this.companyName; }
            set { this.companyName = value; }
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
        public string ContactName
        {
            get { return this.contactName; }
            set { this.contactName = value; }
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
        public string HomePage
        {
            get { return this.homePage; }
            set { this.homePage = value; }
        }
        public Suppliers() : this(-1, "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a")
        {

        }

        public Suppliers(string aCompanyname) : this(-1, aCompanyname, "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a")
        {

        }

        public Suppliers(int supplierid, string companyname, string contacttitle, string adress, string city, string postalcode, string country, string phone, string fax, string homepage)
        {
            SupplierId = supplierid;
            CompanyName = companyname;
            ContactTitle = contacttitle;
            Address = adress;
            City = city;
            PostalCode = postalcode;
            Country = country;
            Phone = phone;
            Fax = fax;
            HomePage = homepage;


        }
    }
}
