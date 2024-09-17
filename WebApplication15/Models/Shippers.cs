namespace WebApplication15.Models
{
    public class Shippers
    {
        private int shipperId = -1;
        private string companyName = string.Empty;
        private string phonenum = "123456789"; // Assuming default value is a string

        public int ShipperId
        {
            get { return shipperId; }
            set { shipperId = value; }
        }

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public string Phonenum
        {
            get { return phonenum; }
            set { phonenum = value; }
        }

        public Shippers() : this(-1, "No Name", "123456789")
        {

        }

        public Shippers(string companyName) : this(-1, companyName, "123456789")
        {

        }

        public Shippers(int aShipperId, string aCompanyName, string aPhonenum)
        {
            this.ShipperId = aShipperId;
            this.CompanyName = aCompanyName;
            this.Phonenum = aPhonenum;
        }
    }
}
