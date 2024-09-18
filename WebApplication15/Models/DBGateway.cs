

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using WebApplication15.Models;
using System.Diagnostics;
using System.Net;








namespace WebApplication15.Models
{
    public class DBGateway
    {
        public List<Products> GetProducts()
        {
            List<Products> listOfProducts = new List<Products>();
            Products aProduct;

            long productId = 0;
            string productName = "n/a";
            long supplierId = 0;
            long categoryId = 0;
            double unitPrice = 99999.99;

            SqliteConnection connection = DB_Connection.GetConnection();

            // First we open the connection
            connection.Open();


            //Create Command
            SqliteCommand command = connection.CreateCommand();

            //Set up our SQL Statement
            command.CommandText = "select productid, productname, supplierid, categoryid,unitprice from products;";


            //Now run the sql statement
            SqliteDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                //try to access different columns in the table
                //local variable name = (cast) reader ["database column name"];

                //The conversions are because the C# data types do not match the
                //SQLite datatypes, they are from different companies
                productId = (long)reader["productId"];
                productName = (string)reader["productname"];
                supplierId = (long)reader["supplierid"];
                categoryId = (long)reader["categoryid"];
                unitPrice = Convert.ToDouble(reader["unitPrice"]);

                aProduct = new Products();
                aProduct.ProductId = Convert.ToInt32(productId);
                aProduct.ProductName = productName;
                aProduct.SupplierId = Convert.ToInt32(supplierId);
                aProduct.CategoryId = Convert.ToInt32(categoryId);
                aProduct.UnitPrice = unitPrice;


                //Every time we loop we will create one new product and add it to the list
                listOfProducts.Add(aProduct);
            }
            connection.Close();
            return listOfProducts;
        }

        public List<Products> GetProductById(int aProductId)
        {

            List<Products> listOfProducts = new List<Products>();
            Products aProduct;


            long productId = 0;
            string productName = "n/a";
            long supplierId = 0;
            long categoryId = 0;
            double unitPrice = 999999.99;

            SqliteConnection connection = DB_Connection.GetConnection();


            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add("@productid", SqliteType.Integer).Value = aProductId;

            // Third, set up our SQL statement
            // an evil hacker could send a string like "10; drop table products"

            command.CommandText = "select productid, productname, supplierid, categoryid, unitprice " +
                "from products where productid = @productid";

            // we could even go further and make this whole thing a stored procedure
            // where the database would do another check to make sure there was no sql injection



            // Forth run the sql statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader ["database column name"];

                // The conversions are because the C# data types do not match the 
                // SQLite datatypes, they are from different companies
                productId = (long)reader["productId"];
                productName = (string)reader["productname"];
                supplierId = (long)reader["supplierid"];
                categoryId = (long)reader["categoryid"];
                unitPrice = Convert.ToDouble(reader["unitprice"]);

                aProduct = new Products();

                aProduct.ProductId = Convert.ToInt32(productId);
                aProduct.ProductName = productName;
                aProduct.SupplierId = Convert.ToInt32(supplierId);
                aProduct.CategoryId = Convert.ToInt32(categoryId);
                aProduct.UnitPrice = unitPrice;

                // Every time we loop we will create one new product and add it to the list
                listOfProducts.Add(aProduct);

            }

            connection.Close();

            return listOfProducts;

        }
        public List<Categories> InsertACategory(string aName, string aDesc)
        {
            SqliteConnection connection = DB_Connection.GetConnection();
            connection.Open();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO categories(categoryName, description) VALUES(@catname, @desc);";
            command.Parameters.Add("@catname", SqliteType.Text).Value = aName;
            command.Parameters.Add("@desc", SqliteType.Text).Value = aDesc;

            command.ExecuteNonQuery();

            // Retrieve the updated list of categories after insertion
            List<Categories> listOfCategories = GetCategories();

            return listOfCategories;
        }

        public List<Products> InsertAProduct(string aProductName, int aSupplierId, int aCategoryId, double aUnitPrice)
        {
            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "insert into products(productname, supplierid, categoryid, unitprice) values" + "(@productname, @supplierid, @categoryid, @unitprice);";
            command.Parameters.Add(@"productname", SqliteType.Text).Value = aProductName;
            command.Parameters.Add(@"supplierid", SqliteType.Integer).Value = aSupplierId;
            command.Parameters.Add(@"categoryid", SqliteType.Integer).Value = aCategoryId;
            command.Parameters.Add(@"unitprice", SqliteType.Real).Value = aUnitPrice;

            command.ExecuteNonQuery();
            List<Products> listOfProducts = new List<Products>();
            return listOfProducts;
        }
        public List<Suppliers> GetSuppliers()
        {

            List<Suppliers> listOfSuppliers = new List<Suppliers>();
            Suppliers aSupplier;


            long supplierId = 0;
            string companyName = "n/a";
            string contactTitle = "n/a";
            string address = "n/a";
            string city = "n/a";
            string contactName = "n/a";
            string postalCode = "n/a";
            string country = "n/a";
            string phone = "n/a";
            string fax = "n/a";
            string homePage = "n/a";

            SqliteConnection connection = DB_Connection.GetConnection();


            connection.Open();


            SqliteCommand command = connection.CreateCommand();

            command.CommandText = "select supplierid, companyname, contacttitle, address, city, contactname, postalcode, country, phone, fax, homepage from suppliers;";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                supplierId = (long)reader["supplierid"];
                companyName = reader["companyname"] == DBNull.Value ? null : (string)reader["companyname"];
                contactTitle = reader["contacttitle"] == DBNull.Value ? null : (string)reader["contacttitle"];
                address = reader["address"] == DBNull.Value ? null : (string)reader["address"];
                city = reader["city"] == DBNull.Value ? null : (string)reader["city"];
                contactName = reader["contactname"] == DBNull.Value ? null : (string)reader["contactname"];
                postalCode = reader["postalCode"] == DBNull.Value ? null : (string)reader["postalCode"];
                country = reader["country"] == DBNull.Value ? null : (string)reader["country"];
                phone = reader["phone"] == DBNull.Value ? null : (string)reader["phone"];
                fax = reader["fax"] == DBNull.Value ? null : (string)reader["fax"];
                homePage = reader["homepage"] == DBNull.Value ? null : (string)reader["homepage"];


                // Now I put it in a C# class
                aSupplier = new Suppliers();

                aSupplier.SupplierId = Convert.ToInt32(supplierId);
                aSupplier.CompanyName = companyName;
                aSupplier.ContactTitle = contactTitle;
                aSupplier.Address = address;
                aSupplier.City = city;
                aSupplier.ContactName = contactName;
                aSupplier.PostalCode = postalCode;
                aSupplier.Country = country;
                aSupplier.Phone = phone;
                aSupplier.Fax = fax;
                aSupplier.HomePage = homePage;



                // Every time we loop we will create one new product and add it to the list
                listOfSuppliers.Add(aSupplier);

            }

            connection.Close();

            return listOfSuppliers;

        }

        public List<Categories> GetCategories()
        {
            List<Categories> listOfCategories = new List<Categories>();
            Categories aCategory;
            long categoryId = 0;
            string categoryName = "n/a";
            string description = "N/a";

            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open();


            SqliteCommand command = connection.CreateCommand();

            command.CommandText = "select categoryid, categoryname, description from categories;";


            SqliteDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                categoryId = (long)reader["categoryid"];
                categoryName = (string)reader["categoryname"];
                description = (string)reader["description"];


                aCategory = new Categories();
                aCategory.CategoryId = Convert.ToInt32(categoryId);
                aCategory.CategoryName = categoryName;
                aCategory.Description = description;


                listOfCategories.Add(aCategory);

            }
            connection.Close();
            return listOfCategories;
        }

        public List<Products> UpdateAProduct(int aProductId, string aProductName, int aSupplierId, int aCategoryId, double aUnitPrice)
        {


            SqliteConnection connection = DB_Connection.GetConnection();


            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "update Products " +
                "set productname = @productname, " +
                "supplierId = @supplierid, " +
                "categoryId = @categoryid, " +
                "unitPrice=@unitprice " +
                "where productId = @productid;";

            command.Parameters.Add("@productid", SqliteType.Text).Value = aProductId;
            command.Parameters.Add("@productname", SqliteType.Text).Value = aProductName;
            command.Parameters.Add("@supplierid", SqliteType.Integer).Value = aSupplierId;
            command.Parameters.Add("@categoryid", SqliteType.Integer).Value = aCategoryId;
            command.Parameters.Add("@unitprice", SqliteType.Real).Value = aUnitPrice;


            // Forth run the sql statement
            command.ExecuteNonQuery();

            // Then I return the new List after the insertion
            List<Products> listOfProducts = this.GetProducts();

            return listOfProducts;
        }

        public List<Categories> UpdateACategory(int aCategoryId, string aCategoryName, string aDescription)
        {
            // Get a connection to the database
            SqliteConnection connection = DB_Connection.GetConnection();

            // Open the connection
            connection.Open();

            // Create a command
            SqliteCommand command = connection.CreateCommand();

            // Set up the SQL statement
            command.CommandText = "UPDATE Categories " +
                                  "SET CategoryName = @categoryName, " +
                                  "Description = @description " +
                                  "WHERE CategoryId = @categoryId;";

            // Add parameters
            command.Parameters.Add("@categoryId", SqliteType.Integer).Value = aCategoryId;
            command.Parameters.Add("@categoryName", SqliteType.Text).Value = aCategoryName;
            command.Parameters.Add("@description", SqliteType.Text).Value = aDescription;

            // Execute the SQL statement
            command.ExecuteNonQuery();

            // Close the connection
            connection.Close();

            // Return the updated list of categories
            return GetCategories();
        }

        public List<Employees> GetEmployees()
        {
            List<Employees> listOfEmployees = new List<Employees>();
            Employees anEmployee;
            long employeeId = 1;
            string lastName = "n/a";
            string firstName = "n/a";
            string title = "n/a";
            string titleOfCourtesy = "n/a";
            string birthDate = "n/a"; ;
            string hireDate = "n/a"; ;
            string address = "n/a";
            string city = "n/a";
            /*string region = "n/a";*/
            string postalCode = "n/a";
            string country = "n/a";
            string homePhone = "n/a";
            string extension = "n/a";
            string notes = "n/a";
            /*long reportsTo = -1;*/

            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.CommandText = "select employeeid, lastname, firstname, title, titleofcourtesy, birthdate, hiredate, address, city, postalcode, country, homephone, extension, notes   from employees;";


            SqliteDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                //try to access different columns in the table
                //local variable name = (cast) reader ["database column name"];

                //The conversions are because the C# data types do not match the
                //SQLite datatypes, they are from different companies
                employeeId = (long)reader["employeeid"];
                lastName = (string)reader["lastname"];
                firstName = (string)reader["firstname"];
                title = (string)reader["title"];
                titleOfCourtesy = (string)reader["titleofcourtesy"];
                birthDate = (string)reader["birthdate"];
                hireDate = (string)reader["hiredate"];
                address = (string)reader["address"];
                city = (string)reader["city"];
                /*region = (string)reader["region"];*/
                postalCode = (string)reader["postalcode"];
                country = (string)reader["country"];
                homePhone = (string)reader["homePhone"];
                extension = (string)reader["extension"];
                notes = (string)reader["notes"];
                /*reportsTo = (int)reader["reportsto"];*/



                anEmployee = new Employees();
                anEmployee.EmployeeId = Convert.ToInt32(employeeId);
                anEmployee.LastName = lastName;
                anEmployee.FirstName = firstName;
                anEmployee.Title = title;
                anEmployee.TitleOfCourtesy = titleOfCourtesy;
                anEmployee.BirthDate = birthDate;
                anEmployee.HireDate = hireDate;
                anEmployee.Address = address;
                anEmployee.City = city;
                /*anEmployee.Region = region;*/
                anEmployee.PostalCode = postalCode;
                anEmployee.Country = country;
                anEmployee.HomePhone = homePhone;
                anEmployee.Extension = extension;
                anEmployee.Notes = notes;
                /* anEmployee.ReportsTo = Convert.ToInt32(reportsTo);*/


                //Every time we loop we will create one new product and add it to the list
                listOfEmployees.Add(anEmployee);
            }
            connection.Close();
            return listOfEmployees;

        }

        public List<Employees> GetEmployeesById(int anEmployeeId)
        {
            List<Employees> listOfEmployees = new List<Employees>();
            Employees anEmployee;
            long employeeId = 1;
            string lastName = "n/a";
            string firstName = "n/a";
            string title = "n/a";
            string titleOfCourtesy = "n/a";
            string birthDate = "n/a"; ;
            string hireDate = "n/a"; ;
            string address = "n/a";
            string city = "n/a";
            /*string region = "n/a";*/
            string postalCode = "n/a";
            string country = "n/a";
            string homePhone = "n/a";
            string extension = "n/a";
            byte[] photo;
            string notes = "n/a";
            /*long reportsTo = -1;*/

            SqliteConnection connection = DB_Connection.GetConnection();
            connection.Open();

            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add("@employeeid", SqliteType.Integer).Value = anEmployeeId;


            command.CommandText = "select employeeid, lastname, firstname, title, titleofcourtesy, birthdate, hiredate, address, city, postalcode, country, homephone, extension, notes " +
                "from employees where employeeid = @employeeid";




            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                employeeId = (long)reader["employeeid"];
                lastName = (string)reader["lastname"];
                firstName = (string)reader["firstname"];
                title = (string)reader["title"];
                titleOfCourtesy = (string)reader["titleofcourtesy"];
                birthDate = (string)reader["birthdate"];
                hireDate = (string)reader["hiredate"];
                address = (string)reader["address"];
                city = (string)reader["city"];
                /*region = (string)reader["region"];*/
                postalCode = (string)reader["postalcode"];
                country = (string)reader["country"];
                homePhone = (string)reader["homePhone"];
                extension = (string)reader["extension"];
                notes = (string)reader["notes"];
                /*reportsTo = (int)reader["resportsto"];*/



                anEmployee = new Employees();
                anEmployee.EmployeeId = Convert.ToInt32(employeeId);
                anEmployee.LastName = lastName;
                anEmployee.FirstName = firstName;
                anEmployee.Title = title;
                anEmployee.TitleOfCourtesy = titleOfCourtesy;
                anEmployee.BirthDate = birthDate;
                anEmployee.HireDate = hireDate;
                anEmployee.Address = address;
                anEmployee.City = city;
                /*anEmployee.Region = region;*/
                anEmployee.PostalCode = postalCode;
                anEmployee.Country = country;
                anEmployee.HomePhone = homePhone;
                anEmployee.Extension = extension;
                anEmployee.Notes = notes;
                /*anEmployee.ReportsTo = Convert.ToInt32(reportsTo);*/


                listOfEmployees.Add(anEmployee);
            }
            connection.Close();
            return listOfEmployees;
        }

        public List<Employees> InsertEmployee(string aLastName, string aFirstName, string aTitle, string aTitleOfCourtesy, string aBirthDate, string aHireDate, string anAddress, string aCity, int aPostalCode, string aCountry, string aHomePhone, int anExtension, string aNotes)
        {
            // Validate required parameters
            if (string.IsNullOrEmpty(aLastName) || string.IsNullOrEmpty(aFirstName) || string.IsNullOrEmpty(aTitle) ||
                string.IsNullOrEmpty(aBirthDate) || string.IsNullOrEmpty(aHireDate) || string.IsNullOrEmpty(anAddress) ||
                string.IsNullOrEmpty(aCity) || string.IsNullOrEmpty(aCountry) || string.IsNullOrEmpty(aHomePhone) ||
                aPostalCode <= 0 || anExtension <= 0)
            {
                Console.WriteLine("Invalid input: All required parameters must be provided.");
                return new List<Employees>(); // Return an empty list
            }

            try
            {
                using (SqliteConnection connection = DB_Connection.GetConnection())
                {
                    connection.Open();
                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO employees(lastname, firstname, title, titleofcourtesy, birthdate, hiredate, address, city, postalcode, country, homephone, extension, notes) " +
                                              "VALUES (@lastname, @firstname, @title, @titleofcourtesy, @birthdate, @hiredate, @address, @city, @postalcode, @country, @homephone, @extension, @notes)";

                        // Add parameters with appropriate data types
                        command.Parameters.Add("@lastname", SqliteType.Text).Value = aLastName;
                        command.Parameters.Add("@firstname", SqliteType.Text).Value = aFirstName;
                        command.Parameters.Add("@title", SqliteType.Text).Value = aTitle;
                        command.Parameters.Add("@titleofcourtesy", SqliteType.Text).Value = aTitleOfCourtesy;
                        command.Parameters.Add("@birthdate", SqliteType.Text).Value = aBirthDate;
                        command.Parameters.Add("@hiredate", SqliteType.Text).Value = aHireDate;
                        command.Parameters.Add("@address", SqliteType.Text).Value = anAddress;
                        command.Parameters.Add("@city", SqliteType.Text).Value = aCity;
                        command.Parameters.Add("@postalcode", SqliteType.Integer).Value = aPostalCode;
                        command.Parameters.Add("@country", SqliteType.Text).Value = aCountry;
                        command.Parameters.Add("@homephone", SqliteType.Text).Value = aHomePhone;
                        command.Parameters.Add("@extension", SqliteType.Integer).Value = anExtension;
                        command.Parameters.Add("@notes", SqliteType.Text).Value = aNotes;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting employee: " + ex.Message);
                return new List<Employees>(); // Return an empty list
            }

            // Return a list of employees (in this case, empty since no employees were retrieved)
            return new List<Employees>();
        }


        public List<Employees> UpdateAnEmployee(int anEmployeeId, string aLastName, string aFirstName, string aTitle, string aTitleOfCourtesy, string aBirthDate, string aHireDate, string anAddress, string aCity, string aPostalCode, string aCountry, string aHomePhone, string anExtension, string aNotes)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Employees " +
                        "SET lastname = @lastname, " +
                        "firstname = @firstname, " +
                        "title = @title, " +
                        "titleofcourtesy = @titleofcourtesy, " +
                        "birthdate = @birthdate, " +
                        "hiredate = @hiredate, " +
                        "address = @address, " +
                        "city = @city, " +
                        "postalcode = @postalcode, " +
                        "country = @country, " +
                        "homephone = @homephone, " +
                        "extension = @extension, " +
                        "notes = @notes " +
                        "WHERE employeeid = @employeeid";

                    command.Parameters.Add("@lastname", SqliteType.Text).Value = aLastName;
                    command.Parameters.Add("@firstname", SqliteType.Text).Value = aFirstName;
                    command.Parameters.Add("@title", SqliteType.Text).Value = aTitle;
                    command.Parameters.Add("@titleofcourtesy", SqliteType.Text).Value = aTitleOfCourtesy;
                    command.Parameters.Add("@birthdate", SqliteType.Text).Value = aBirthDate;
                    command.Parameters.Add("@hiredate", SqliteType.Text).Value = aHireDate;
                    command.Parameters.Add("@address", SqliteType.Text).Value = anAddress;
                    command.Parameters.Add("@city", SqliteType.Text).Value = aCity;
                    command.Parameters.Add("@postalcode", SqliteType.Text).Value = aPostalCode;
                    command.Parameters.Add("@country", SqliteType.Text).Value = aCountry;
                    command.Parameters.Add("@homephone", SqliteType.Text).Value = aHomePhone;
                    command.Parameters.Add("@extension", SqliteType.Text).Value = anExtension;
                    command.Parameters.Add("@notes", SqliteType.Text).Value = aNotes;
                    command.Parameters.Add("@employeeid", SqliteType.Integer).Value = anEmployeeId;

                    command.ExecuteNonQuery();
                }
            }

            List<Employees> listOfEmployees = this.GetEmployees();
            return listOfEmployees;
        }




        public List<Orders> GetOrders()
        {
            List<Orders> listOfOrders = new List<Orders>();
            Orders anOrder;
            long orderId = 1;
            string customerId = "n/a";
            long employeeId = -1;
            string orderDate = "n/a";
            string requiredDate = "n/a";
            string shippedDate = "n/a";
            int shipVia = 1;
            decimal freight = Decimal.MaxValue;
            string shipName = "n/a";
            string shipAddress = "n/a";
            string shipCity = "n/a";
            string shipRegion = "n/a";
            string shipPostalCode = "n/a";
            string shipCountry = "n/a";

            SqliteConnection connection = DB_Connection.GetConnection();
            // First we open the connection
            connection.Open();

            // Create Command
            SqliteCommand command = connection.CreateCommand();

            // Set up our SQL Statement
            command.CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders;";

            // Now run the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Assign values from the reader to variables
                orderId = reader["OrderID"] != DBNull.Value ? Convert.ToInt32(reader["OrderID"]) : -1;
                customerId = reader["CustomerID"] != DBNull.Value ? (string)reader["CustomerID"] : "n/a";
                employeeId = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : -1;
                orderDate = reader["OrderDate"] != DBNull.Value ? Convert.ToDateTime(reader["OrderDate"]).ToString() : "n/a";
                requiredDate = reader["RequiredDate"] != DBNull.Value ? Convert.ToDateTime(reader["RequiredDate"]).ToString() : "n/a";
                shippedDate = reader["ShippedDate"] != DBNull.Value ? Convert.ToDateTime(reader["ShippedDate"]).ToString() : "n/a";
                shipVia = reader["ShipVia"] != DBNull.Value ? Convert.ToInt32(reader["ShipVia"]) : -1;
                freight = reader["Freight"] != DBNull.Value ? Convert.ToDecimal(reader["Freight"]) : Decimal.MaxValue;
                shipName = reader["ShipName"] != DBNull.Value ? (string)reader["ShipName"] : "n/a";
                shipAddress = reader["ShipAddress"] != DBNull.Value ? (string)reader["ShipAddress"] : "n/a";
                shipCity = reader["ShipCity"] != DBNull.Value ? (string)reader["ShipCity"] : "n/a";
                shipRegion = reader["ShipRegion"] != DBNull.Value ? (string)reader["ShipRegion"] : "n/a";
                shipPostalCode = reader["ShipPostalCode"] != DBNull.Value ? (string)reader["ShipPostalCode"] : "n/a";
                shipCountry = reader["ShipCountry"] != DBNull.Value ? (string)reader["ShipCountry"] : "n/a";

                // Create new Orders object and populate its properties
                anOrder = new Orders();
                anOrder.OrderId = Convert.ToInt32(orderId);
                anOrder.CustomerId = customerId;
                anOrder.EmployeeId = Convert.ToInt32(employeeId);
                anOrder.OrderDate = orderDate;
                anOrder.RequiredDate = requiredDate;
                anOrder.ShippedDate = shippedDate;
                anOrder.ShipVia = shipVia;
                anOrder.Freight = freight;
                anOrder.ShipName = shipName;
                anOrder.ShipAddress = shipAddress;
                anOrder.ShipCity = shipCity;
                anOrder.ShipRegion = shipRegion;
                anOrder.ShipPostalCode = shipPostalCode;
                anOrder.ShipCountry = shipCountry;

                // Add the newly created Orders object to the list
                listOfOrders.Add(anOrder);
            }

            // Close the connection
            connection.Close();

            return listOfOrders;
        }
        public List<Orders> GetOrdersById(int anOrderId)
        {
            List<Orders> listOfOrders = new List<Orders>();

            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.Parameters.Add("@orderId", SqliteType.Integer).Value = anOrderId;
                    command.CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry " +
                                          "FROM Orders WHERE OrderID = @orderId";

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders order = new Orders
                            {
                                OrderId = Convert.ToInt32(reader["OrderID"]),
                                CustomerId = reader["CustomerID"].ToString(),
                                EmployeeId = Convert.ToInt32(reader["EmployeeID"]),
                                OrderDate = reader["OrderDate"].ToString(),
                                RequiredDate = reader["RequiredDate"].ToString(),
                                ShippedDate = reader["ShippedDate"].ToString(),
                                ShipVia = Convert.ToInt32(reader["ShipVia"]),
                                Freight = Convert.ToDecimal(reader["Freight"]),
                                ShipName = reader["ShipName"].ToString(),
                                ShipAddress = reader["ShipAddress"].ToString(),
                                ShipCity = reader["ShipCity"].ToString(),
                                ShipRegion = reader["ShipRegion"].ToString(),
                                ShipPostalCode = reader["ShipPostalCode"].ToString(),
                                ShipCountry = reader["ShipCountry"].ToString()
                            };

                            listOfOrders.Add(order);
                        }
                    }
                }
            }

            return listOfOrders;
        }

        public List<Orders> InsertOrder(string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) " +
                                          "VALUES (@customerId, @employeeId, @orderDate, @requiredDate, @shippedDate, @shipVia, @freight, @shipName, @shipAddress, @shipCity, @shipRegion, @shipPostalCode, @shipCountry)";
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    command.Parameters.AddWithValue("@orderDate", orderDate);
                    command.Parameters.AddWithValue("@requiredDate", requiredDate);
                    command.Parameters.AddWithValue("@shippedDate", shippedDate);
                    command.Parameters.AddWithValue("@shipVia", shipVia);
                    command.Parameters.AddWithValue("@freight", freight);
                    command.Parameters.AddWithValue("@shipName", shipName);
                    command.Parameters.AddWithValue("@shipAddress", shipAddress);
                    command.Parameters.AddWithValue("@shipCity", shipCity);
                    command.Parameters.AddWithValue("@shipRegion", shipRegion);
                    command.Parameters.AddWithValue("@shipPostalCode", shipPostalCode);
                    command.Parameters.AddWithValue("@shipCountry", shipCountry);

                    command.ExecuteNonQuery();
                }
            }

            // Retrieve and return the updated list of orders
            List<Orders> listOfOrders = this.GetOrders();
            return listOfOrders;
        }
        public List<OrderDetails> InsertOrderDetails(int orderId, int productId, double unitPrice, int quantity, int discount)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Order Details] (ORDERID, PRODUCTID, UNITPRICE, QUANTITY, DISCOUNT) " +
                                          "VALUES (@orderId, @productId, @unitPrice, @quantity, @discount)";
                    command.Parameters.AddWithValue("@orderId", orderId);
                    command.Parameters.AddWithValue("@productId", productId);
                    command.Parameters.AddWithValue("@unitPrice", unitPrice);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@discount", discount);


                    command.ExecuteNonQuery();
                }
            }

            // Retrieve and return the updated list of orders
            List<OrderDetails> listOfOrderDetails = this.GetOrderDetails();
            return listOfOrderDetails;
        }

        public List<Orders> UpdateOrder(int orderId, string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Orders " +
                                          "SET CustomerID = @customerId, EmployeeID = @employeeId, OrderDate = @orderDate, RequiredDate = @requiredDate, ShippedDate = @shippedDate, ShipVia = @shipVia, Freight = @freight, ShipName = @shipName, ShipAddress = @shipAddress, ShipCity = @shipCity, ShipRegion = @shipRegion, ShipPostalCode = @shipPostalCode, ShipCountry = @shipCountry " +
                                          "WHERE OrderID = @orderId";
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    command.Parameters.AddWithValue("@orderDate", orderDate);
                    command.Parameters.AddWithValue("@requiredDate", requiredDate);
                    command.Parameters.AddWithValue("@shippedDate", shippedDate);
                    command.Parameters.AddWithValue("@shipVia", shipVia);
                    command.Parameters.AddWithValue("@freight", freight);
                    command.Parameters.AddWithValue("@shipName", shipName);
                    command.Parameters.AddWithValue("@shipAddress", shipAddress);
                    command.Parameters.AddWithValue("@shipCity", shipCity);
                    command.Parameters.AddWithValue("@shipRegion", shipRegion);
                    command.Parameters.AddWithValue("@shipPostalCode", shipPostalCode);
                    command.Parameters.AddWithValue("@shipCountry", shipCountry);
                    command.Parameters.AddWithValue("@orderId", orderId);

                    command.ExecuteNonQuery();
                }
            }

            // Retrieve and return the updated list of orders
            List<Orders> listOfOrders = this.GetOrders();
            return listOfOrders;
        }
        public List<OrderDetails> GetOrderDetails()
        {
            List<OrderDetails> listOfOrderDetails = new List<OrderDetails>();
            OrderDetails anOrderDetail;

            // Initial values for the properties of OrderDetails
            int orderId = -1;
            int productId = -1;
            double unitPrice = double.MaxValue;
            int quantity = -1;
            int discount = -1;

            // Initialize connection to the SQLite database
            SqliteConnection connection = DB_Connection.GetConnection();
            connection.Open(); // First we open the connection

            // Create Command
            SqliteCommand command = connection.CreateCommand();

            // Set up our SQL Statement
            command.CommandText = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details];";

            // Now run the sql statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Access different columns in the table
                orderId = Convert.ToInt32(reader["OrderID"]);
                productId = Convert.ToInt32(reader["ProductID"]);
                unitPrice = Convert.ToDouble(reader["UnitPrice"]);
                quantity = Convert.ToInt32(reader["Quantity"]);
                discount = Convert.ToInt32(reader["Discount"]);

                anOrderDetail = new OrderDetails(orderId, productId, unitPrice, quantity, discount);

                // Every time we loop we will create one new OrderDetail and add it to the list
                listOfOrderDetails.Add(anOrderDetail);
            }

            connection.Close(); // Finally, close the connection
            return listOfOrderDetails;
        }
        public List<OrderDetails> GetOrderDetailsById(int anOrderId)
        {
            List<OrderDetails> listOfOrderDetails = new List<OrderDetails>();
            OrderDetails anOrderDetail;

            // Initial values for the properties of OrderDetails
            int orderId = -1;
            int productId = -1;
            double unitPrice = double.MaxValue;
            int quantity = -1;
            int discount = -1;

            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open(); // First try to open the connection

            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add(new SqliteParameter("@orderId", anOrderId)); // Prevent SQL injection

            // Set up our SQL statement
            command.CommandText = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details] WHERE OrderID = @orderId;";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderId = Convert.ToInt32(reader["OrderID"]);
                productId = Convert.ToInt32(reader["ProductID"]);
                unitPrice = Convert.ToDouble(reader["UnitPrice"]);
                quantity = Convert.ToInt32(reader["Quantity"]);
                discount = Convert.ToInt32(reader["Discount"]);

                anOrderDetail = new OrderDetails(orderId, productId, unitPrice, quantity, discount);

                // Every time we loop we will create one new OrderDetail and add it to the list
                listOfOrderDetails.Add(anOrderDetail);
            }

            connection.Close(); // Close the connection

            return listOfOrderDetails;
        }

        public List<Categories> GetCategoriesById(int aCategoryId)
        {
            List<Categories> listOfCategories = new List<Categories>();
            Categories aCategory;

            // Initial values for the properties of OrderDetails
            int categoryId = -1;
            string categoryName = "n/a";
            string description = "n/a";


            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open(); // First try to open the connection

            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add(new SqliteParameter("@aCategoryId", aCategoryId)); // Prevent SQL injection

            // Set up our SQL statement
            command.CommandText = "SELECT categoryId, categoryname, description FROM Categories WHERE categoryId = @aCategoryId;";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categoryId = Convert.ToInt32(reader["categoryId"]);
                categoryName = reader["categoryname"].ToString();
                description = reader["description"].ToString();


                aCategory = new Categories(categoryId, categoryName, description);

                // Every time we loop we will create one new OrderDetail and add it to the list
                listOfCategories.Add(aCategory);
            }

            connection.Close(); // Close the connection

            return listOfCategories;
        }


        public List<OrderDetails> UpdateAnOrderDetail(int orderId, int productId, double unitPrice, int quantity, int discount)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "update [Order Details] set UnitPrice = @unitPrice, Quantity = @quantity, Discount = @discount where OrderId = @orderId AND ProductId = @productId;";
                    command.Parameters.Add("@orderId", SqliteType.Integer).Value = orderId;
                    command.Parameters.Add("@productId", SqliteType.Integer).Value = productId;
                    command.Parameters.Add("@unitPrice", SqliteType.Real).Value = unitPrice;
                    command.Parameters.Add("@quantity", SqliteType.Integer).Value = quantity;
                    command.Parameters.Add("@discount", SqliteType.Integer).Value = discount;

                    command.ExecuteNonQuery();
                }
            }

            // Assuming GetOrderDetails is a method that retrieves all order details from the database
            List<OrderDetails> listOfOrderDetails = this.GetOrderDetails();

            return listOfOrderDetails;
        }


        public List<Shippers> GetShippers()
        {
            List<Shippers> listOfShippers = new List<Shippers>();
            Shippers aShipper;
            int shipperId = -1;
            string companyName = "n/a";
            string phonenum = "123456789"; // Change type to string

            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open();

            SqliteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT ShipperID, CompanyName, Phone FROM Shippers";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                shipperId = Convert.ToInt32(reader["ShipperID"]);
                companyName = Convert.ToString(reader["CompanyName"]);
                phonenum = Convert.ToString(reader["Phone"]); // Convert to string directly

                aShipper = new Shippers();
                aShipper.ShipperId = shipperId;
                aShipper.CompanyName = companyName;
                aShipper.Phonenum = phonenum; // Assign as string

                listOfShippers.Add(aShipper);
            }

            connection.Close();
            return listOfShippers;
        }

        public Shippers GetShipperById(int aShipperId)
        {
            Shippers shipper = null;
            SqliteConnection connection = DB_Connection.GetConnection();

            connection.Open();

            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add(new SqliteParameter("@shipperId", aShipperId)); // Prevent SQL injection

            command.CommandText = "SELECT ShipperID, CompanyName, Phone FROM Shippers WHERE ShipperID = @shipperId;";

            SqliteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                int shipperId = Convert.ToInt32(reader["ShipperID"]);
                string companyName = Convert.ToString(reader["CompanyName"]);
                string phonenum = Convert.ToString(reader["Phone"]); // Convert to string directly

                shipper = new Shippers(shipperId, companyName, phonenum);
            }

            connection.Close();
            return shipper;
        }

        public void InsertShipper(int shipperId, string companyName, string phoneNumber)
        {
            // Basic validation for input parameters
            if (shipperId <= 0)
            {
                throw new ArgumentException("Shipper ID must be greater than 0.", nameof(shipperId));
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentException("Company name cannot be null or empty.", nameof(companyName));
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(phoneNumber));
            }

            try
            {
                using (SqliteConnection connection = DB_Connection.GetConnection())
                {
                    connection.Open();
                    using (SqliteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO Shippers (ShipperID, CompanyName, Phone) " +
                                              "VALUES (@shipperId, @companyName, @phoneNumber)";
                        command.Parameters.AddWithValue("@shipperId", shipperId);
                        command.Parameters.AddWithValue("@companyName", companyName);
                        command.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while inserting shipper: " + ex.Message);
                throw;
            }
        }


        public void UpdateShipper(int shipperId, string companyName, string phonenum)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Shippers SET CompanyName = @companyName, Phone = @phonenum WHERE ShipperID = @shipperId;";
                    command.Parameters.Add("@companyName", SqliteType.Text).Value = companyName;
                    command.Parameters.Add("@phonenum", SqliteType.Text).Value = phonenum;
                    command.Parameters.Add("@shipperId", SqliteType.Integer).Value = shipperId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Customers> GetCustomers()
        {
            List<Customers> listOfCustomers = new List<Customers>();
            Customers aCustomer;

            string customerId = "n/a";
            string companyName = "n/a";
            string contactName = "n/a";
            string contactTitle = "n/a";
            string address = "n/a";
            string city = "n/a";
            string region = "n/a";
            string postalCode = "n/a";
            string country = "n/a";
            string phone = "n/a";
            string fax = "n/a";

            SqliteConnection connection = DB_Connection.GetConnection();
            // First, we open the connection
            connection.Open();

            // Create Command
            SqliteCommand command = connection.CreateCommand();

            // Set up our SQL Statement
            command.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers;";

            // Now run the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access different columns in the table
                // Local variable name = (cast) reader["database column name"];

                customerId = reader["CustomerID"].ToString();
                companyName = reader["CompanyName"].ToString();
                contactName = reader["ContactName"].ToString();
                contactTitle = reader["ContactTitle"].ToString();
                address = reader["Address"].ToString();
                city = reader["City"].ToString();
                region = reader["Region"].ToString();
                postalCode = reader["PostalCode"].ToString();
                country = reader["Country"].ToString();
                phone = reader["Phone"].ToString();
                fax = reader["Fax"].ToString();

                aCustomer = new Customers();
                aCustomer.CustomerId = customerId;
                aCustomer.CompanyName = companyName;
                aCustomer.ContactName = contactName;
                aCustomer.ContactTitle = contactTitle;
                aCustomer.Address = address;
                aCustomer.City = city;
                aCustomer.Region = region;
                aCustomer.PostalCode = postalCode;
                aCustomer.Country = country;
                aCustomer.Phone = phone;
                aCustomer.Fax = fax;

                // Every time we loop, we will create one new customer and add it to the list
                listOfCustomers.Add(aCustomer);
            }

            connection.Close();
            return listOfCustomers;
        }

        public List<Customers> GetCustomerById(string customerId)
        {
            List<Customers> listOfCustomers = new List<Customers>();
            Customers aCustomer;

            string companyName = "n/a";
            string contactName = "n/a";
            string contactTitle = "n/a";
            string address = "n/a";
            string city = "n/a";
            string region = "n/a";
            string postalCode = "n/a";
            string country = "n/a";
            string phone = "n/a";
            string fax = "n/a";

            SqliteConnection connection = DB_Connection.GetConnection();

            // First, try to open the connection
            connection.Open();

            // Second, create a command
            SqliteCommand command = connection.CreateCommand();
            command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;

            // Third, set up our SQL statement
            command.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax " +
                                  "FROM Customers " +
                                  "WHERE CustomerID = @customerId";

            // Fourth, run the SQL statement
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                // Try to access the different columns in the reader
                // local variable name = (cast) reader["database column name"];

                companyName = reader["CompanyName"].ToString();
                contactName = reader["ContactName"].ToString();
                contactTitle = reader["ContactTitle"].ToString();
                address = reader["Address"].ToString();
                city = reader["City"].ToString();
                region = reader["Region"].ToString();
                postalCode = reader["PostalCode"].ToString();
                country = reader["Country"].ToString();
                phone = reader["Phone"].ToString();
                fax = reader["Fax"].ToString();

                aCustomer = new Customers();
                aCustomer.CustomerId = customerId;
                aCustomer.CompanyName = companyName;
                aCustomer.ContactName = contactName;
                aCustomer.ContactTitle = contactTitle;
                aCustomer.Address = address;
                aCustomer.City = city;
                aCustomer.Region = region;
                aCustomer.PostalCode = postalCode;
                aCustomer.Country = country;
                aCustomer.Phone = phone;
                aCustomer.Fax = fax;

                // Every time we loop, we will create one new customer and add it to the list
                listOfCustomers.Add(aCustomer);
            }

            connection.Close();

            return listOfCustomers;
        }

        public List<Customers> InsertCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            SqliteConnection connection = DB_Connection.GetConnection();
            connection.Open();
            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                                  "VALUES (@customerId, @companyName, @contactName, @contactTitle, @address, @city, @region, @postalCode, @country, @phone, @fax);";
            command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;
            command.Parameters.Add("@companyName", SqliteType.Text).Value = companyName;
            command.Parameters.Add("@contactName", SqliteType.Text).Value = contactName;
            command.Parameters.Add("@contactTitle", SqliteType.Text).Value = contactTitle;
            command.Parameters.Add("@address", SqliteType.Text).Value = address;
            command.Parameters.Add("@city", SqliteType.Text).Value = city;
            command.Parameters.Add("@region", SqliteType.Text).Value = region;
            command.Parameters.Add("@postalCode", SqliteType.Text).Value = postalCode;
            command.Parameters.Add("@country", SqliteType.Text).Value = country;
            command.Parameters.Add("@phone", SqliteType.Text).Value = phone;
            command.Parameters.Add("@fax", SqliteType.Text).Value = fax;

            command.ExecuteNonQuery();

            // Retrieve and return the list of customers after the insertion (not very meaningful for an insert operation, but following the format)
            List<Customers> listOfCustomers = new List<Customers>();
            connection.Close();
            return listOfCustomers;
        }

        public List<Customers> UpdateACustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            SqliteConnection connection = DB_Connection.GetConnection();

            // First try to open the connection
            connection.Open();

            // Second create a command
            SqliteCommand command = connection.CreateCommand();

            // Third, set up our SQL statement
            command.CommandText = "UPDATE Customers " +
                                  "SET CompanyName = @companyName, " +
                                  "ContactName = @contactName, " +
                                  "ContactTitle = @contactTitle, " +
                                  "Address = @address, " +
                                  "City = @city, " +
                                  "Region = @region, " +
                                  "PostalCode = @postalCode, " +
                                  "Country = @country, " +
                                  "Phone = @phone, " +
                                  "Fax = @fax " +
                                  "WHERE CustomerID = @customerId;";

            command.Parameters.Add("@customerId", SqliteType.Text).Value = customerId;
            command.Parameters.Add("@companyName", SqliteType.Text).Value = companyName;
            command.Parameters.Add("@contactName", SqliteType.Text).Value = contactName;
            command.Parameters.Add("@contactTitle", SqliteType.Text).Value = contactTitle;
            command.Parameters.Add("@address", SqliteType.Text).Value = address;
            command.Parameters.Add("@city", SqliteType.Text).Value = city;
            command.Parameters.Add("@region", SqliteType.Text).Value = region;
            command.Parameters.Add("@postalCode", SqliteType.Text).Value = postalCode;
            command.Parameters.Add("@country", SqliteType.Text).Value = country;
            command.Parameters.Add("@phone", SqliteType.Text).Value = phone;
            command.Parameters.Add("@fax", SqliteType.Text).Value = fax;

            // Fourth, run the SQL statement
            command.ExecuteNonQuery();

            // Retrieve and return the updated list of customers
            List<Customers> listOfCustomers = GetCustomers(); // Assuming you have a GetCustomers() method to fetch all customers
            connection.Close();
            return listOfCustomers;
        }

        public List<Suppliers> InsertSupplier(string companyName, string contactTitle, string address, string city, string contactName, string postalCode, string country, string phone, string fax)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Suppliers (CompanyName, ContactTitle, Address, City, ContactName, PostalCode, Country, Phone, Fax) " +
                                          "VALUES (@companyName, @contactTitle, @address, @city ,@contactName, @postalCode, @country, @phone, @fax)";
                    command.Parameters.AddWithValue("@companyName", companyName);
                    command.Parameters.AddWithValue("@contactTitle", contactTitle);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@contactName", contactName);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@fax", fax);

                    command.ExecuteNonQuery();
                }
            }

            List<Suppliers> listOfSuppliers = this.GetSuppliers();

            return listOfSuppliers;
        }


        public List<Suppliers> GetSuppliersById(int aSupplierId)
        {
            List<Suppliers> listOfSuppliers = new List<Suppliers>();

            int supplierId = 0;
            string companyName = "n/a";
            string contactName = "n/a";
            string contactTitle = "n/a";
            string address = "n/a";
            string city = "n/a";
            string postalCode = "n/a";
            string country = "n/a";
            string phone = "n/a";
            string fax = "n/a";

            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();

                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT SupplierId, CompanyName, ContactName, ContactTitle, Address, City, PostalCode, Country, Phone, Fax FROM Suppliers WHERE SupplierId = @supplierId";
                    command.Parameters.Add("@supplierId", SqliteType.Integer).Value = aSupplierId;

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            supplierId = (int)reader.GetInt64(0);
                            companyName = (string)reader["CompanyName"];
                            contactName = (string)reader["ContactName"];
                            contactTitle = (string)reader["ContactTitle"];
                            address = (string)reader["Address"];
                            city = (string)reader["City"];
                            postalCode = (string)reader["PostalCode"];
                            country = (string)reader["Country"];
                            phone = (string)reader["Phone"];
                            fax = reader.IsDBNull(9) ? null : (string)reader["Fax"];

                            Suppliers supplier = new Suppliers();
                            supplier.SupplierId = supplierId;
                            supplier.CompanyName = companyName;
                            supplier.ContactName = contactName;
                            supplier.ContactTitle = contactTitle;
                            supplier.Address = address;
                            supplier.City = city;
                            supplier.PostalCode = postalCode;
                            supplier.Country = country;
                            supplier.Phone = phone;
                            supplier.Fax = fax;

                            listOfSuppliers.Add(supplier);
                        }

                    }
                }
            }

            return listOfSuppliers;
        }



        public void UpdateSupplier(int supplierId, string companyName, string contactTitle, string address, string city, string contactName, string postalCode, string country, string phone, string fax)
        {
            using (SqliteConnection connection = DB_Connection.GetConnection())
            {
                connection.Open();
                using (SqliteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Suppliers SET CompanyName = @companyName, ContactTitle = @contactTitle, Address = @address, City = @city, ContactName= @contactName, PostalCode = @postalCode, Country = @country, Phone = @phone, Fax = @fax WHERE SupplierID = @supplierId;";
                    command.Parameters.AddWithValue("@companyName", companyName);
                    command.Parameters.AddWithValue("@contactTitle", contactTitle);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@postalCode", postalCode);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@fax", fax);
                    command.Parameters.AddWithValue("@contactName", contactName);
                    command.Parameters.AddWithValue("@supplierId", supplierId);

                    command.ExecuteNonQuery();
                }
            }
        }












    }


}

