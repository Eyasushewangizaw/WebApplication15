namespace WebApplication15.Models
{
    public class Employees
    {
        private int employeeId = -1;
        private string lastName = "n/a";
        private string firstName = "n/a";
        private string title = "n/a";
        private string titleOfCourtesy = "n/a";
        private string birthDate = "n/a";
        private string hireDate = "n/a";
        private string address = "n/a";
        private string city = "n/a";
        private string region = "n/a";
        private string postalCode = "n/a";
        private string country = "n/a";
        private string homePhone = "n/a";
        private string extension = "n/a";
        private byte[] photo;
        private string notes = "n/a";
        private int reportsTo = -1;

        public int EmployeeId
        {
            get { return this.employeeId; }
            set { this.employeeId = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string TitleOfCourtesy
        {
            get { return this.titleOfCourtesy; }
            set { this.titleOfCourtesy = value; }
        }

        public string BirthDate
        {
            get { return this.birthDate; }
            set { this.birthDate = value; }
        }

        public string HireDate
        {
            get { return this.hireDate; }
            set { this.hireDate = value; }
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

        public string HomePhone
        {
            get { return this.homePhone; }
            set { this.homePhone = value; }
        }

        public string Extension
        {
            get { return this.extension; }
            set { this.extension = value; }
        }

        public byte[] Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
        }

        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        public int ReportsTo
        {
            get { return this.reportsTo; }
            set { this.reportsTo = value; }
        }


        public Employees() : this(-1, "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", new byte[0], "n/a", -1)
        {

        }

        public Employees(string aFirstName) : this(-1, aFirstName, "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", "n/a", new byte[0], "n/a", -1)
        {

        }

        public Employees(int employeeId, string lastName, string firstName, string title, string titleOfCourtesy, string address, string birthDate, string hireDate, string city, string region, string postalCode, string country, string homePhone, string extension, byte[] photo, string notes, int reportsTo)
        {
            EmployeeId = employeeId;
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            TitleOfCourtesy = titleOfCourtesy;
            Address = address;
            BirthDate = birthDate;
            HireDate = hireDate;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            HomePhone = homePhone;
            Extension = extension;
            Photo = photo;
            Notes = notes;
            ReportsTo = reportsTo;
        }
    }
}