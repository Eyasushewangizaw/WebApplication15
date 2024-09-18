using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication15.Models;
using Microsoft.Data.Sqlite;
using System.Net;
namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            string message = "Welcome to my Website";
            ViewBag.Mesage = message;
            return View();
        }

        public IActionResult GetOrderDetails()
        {
            DBGateway aGateway = new DBGateway();

            List<OrderDetails> aListOfOrderDetails = aGateway.GetOrderDetails();


            ViewBag.ListOfOrderDetails = aListOfOrderDetails;


            return View();
        }
        public IActionResult GetProducts()
        {
            DBGateway aGateway = new DBGateway();

            List<Products> aListOfProdcuts = aGateway.GetProducts();

            ViewBag.ListofProducts = aListOfProdcuts;


            return View();
        }
        public IActionResult GetProductById(int aProductId)
        {
            DBGateway aGateway = new DBGateway();

            List<Products> aListOfProducts = aGateway.GetProductById(aProductId);

            ViewBag.ListOfProducts = aListOfProducts;

            return View();
        }

        public IActionResult GetCategories()
        {
            DBGateway aGateway = new DBGateway();
            List<Categories> aListOfCategories = aGateway.GetCategories();

            ViewBag.ListOfCategories = aListOfCategories;
            return View();
        }


        public IActionResult GetCategoriesById(int aCategoryId)
        {
            DBGateway aGateway = new DBGateway();

            List<Categories> aListOfCategories = aGateway.GetCategoriesById(aCategoryId);

            ViewBag.aListOfCategories = aListOfCategories;

            return View();
        }

        public IActionResult GetSuppliers()
        {
            DBGateway aGateway = new DBGateway();
            List<Suppliers> aListOfSuppliers = aGateway.GetSuppliers();

            ViewBag.ListOfSuppliers = aListOfSuppliers;
            return View();
        }

        //Written by: Adil Abdurahman
        public IActionResult GetEmployees()
        {
            DBGateway aGateway = new DBGateway();

            List<Employees> aListOfEmployees = aGateway.GetEmployees();

            ViewBag.ListofEmployees = aListOfEmployees;


            return View();
        }

        
        public IActionResult GetEmployeeById(int anEmployeeId)
        {
            DBGateway aGateway = new DBGateway();

            List<Employees> aListOfEmployees = aGateway.GetEmployeesById(anEmployeeId);

            ViewBag.ListOfEmployees = aListOfEmployees;

            return View();
        }

        
        public IActionResult InsertEmployeeForm()
        {
            return View();
        }
        
        public IActionResult InsertEmployee(string lastName, string firstName, string title, string titleOfCourtesy, string birthDate, string hireDate, string address, string city, int postalCode, string country, string homePhone, int extension, string notes)
        {

            DBGateway aGateway = new DBGateway();

            aGateway.InsertEmployee(lastName, firstName, title, titleOfCourtesy, birthDate, hireDate, address, city, postalCode, country, homePhone, extension, notes);


            List<Employees> aListOfEmployees = aGateway.GetEmployees();

            ViewBag.ListOfEmployees = aListOfEmployees;


            
            
            return View("GetEmployees");
        }

        
        public IActionResult UpdateAnEmployeeForm(int anEmployeeId)
        {
            DBGateway aGateway = new DBGateway();
            List<Employees> aListOfEmployees = new List<Employees>();

            aListOfEmployees = aGateway.GetEmployeesById(anEmployeeId);

            ViewBag.ListOfEmployees = aListOfEmployees;
            return View();
        }

        
        public IActionResult UpdateAnEmployee(int employeeId, string lastName, string firstName, string title, string titleOfCourtesy, string birthDate, string hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAnEmployee(employeeId, lastName, firstName, title, titleOfCourtesy, birthDate, hireDate, address, city, postalCode, country, homePhone, extension, notes);

            List<Employees> aListOfProducts = new List<Employees>();
            ViewBag.ListOfEmployees = aGateway.GetEmployees();
            return View("GetEmployees");
        }

        public IActionResult InsertACategoryForm()
        {
            return View();
        }


        public IActionResult InsertACategory(string categoryName, string description)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertACategory(categoryName, description);

            List<Categories> aListOfCategories = aGateway.GetCategories();
            ViewBag.ListOfCategories = aListOfCategories;
            return View("GetCategories");
        }

        public IActionResult InsertAProductForm()
        {
            DBGateway aGateway = new DBGateway();

            List<Suppliers> aListOfSuppliers = aGateway.GetSuppliers();
            List<Categories> aListOfCategories = aGateway.GetCategories();

            ViewBag.ListOfSuppliers = aListOfSuppliers;
            ViewBag.ListOfCategories = aListOfCategories;

            return View();
        }

        public IActionResult InsertAProduct(string productName, int supplierId, int categoryId, double unitPrice)
        {

            DBGateway aGateway = new DBGateway();

            aGateway.InsertAProduct(productName, supplierId, categoryId, unitPrice);


            List<Products> aListOfProducts = aGateway.GetProducts();

            ViewBag.ListOfProducts = aListOfProducts;


            
            
            return View("GetProducts");
        }







        public IActionResult UpdateAProductForm(int aProductId)
        {
            DBGateway aGateway = new DBGateway();
            List<Products> aListOfProducts = new List<Products>();
            List<Suppliers> aListOfSuppliers = aGateway.GetSuppliers();
            List<Categories> aListOfCategories = aGateway.GetCategories();

            aListOfProducts = aGateway.GetProductById(aProductId);


            ViewBag.ListOfSuppliers = aListOfSuppliers;
            ViewBag.ListOfCategories = aListOfCategories;
            ViewBag.ListOfProducts = aListOfProducts;

            return View();
        }




        public IActionResult UpdateAProduct(int productId, string productName, int supplierId, int categoryId, double unitPrice)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAProduct(productId, productName, supplierId, categoryId, unitPrice);

            List<Products> aListOfProducts = new List<Products>();
            ViewBag.ListOfProducts = aGateway.GetProducts();
            return View("GetProducts");
        }



        
        

        public IActionResult FilterProducts(string filterBy, string filterValue, double? minimumPrice, double? maximumPrice)
        {
            List<Products> aListOfProducts;
            List<Products> aFilteredListOfProducts;

            DBGateway aGateway = new DBGateway();

            aListOfProducts = aGateway.GetProducts();

            switch (filterBy)
            {
                case "unitPrice":
                    // Perform price filtering
                    if (minimumPrice != null && maximumPrice != null)
                    {
                        var filteredProducts = aListOfProducts.Where(p => p.UnitPrice >= minimumPrice && p.UnitPrice <= maximumPrice);
                        aFilteredListOfProducts = filteredProducts.ToList();
                    }
                    else
                    {
                        // Handle invalid input or no range specified
                        aFilteredListOfProducts = new List<Products>();
                    }
                    break;
                case "productId":
                    // Perform filtering by productId
                    aFilteredListOfProducts = aListOfProducts.Where(p => p.ProductId.ToString() == filterValue).ToList();
                    break;
                case "productName":
                    // Perform filtering by productName
                    aFilteredListOfProducts = aListOfProducts.Where(p => p.ProductName.ToLower().Contains(filterValue.ToLower())).ToList();
                    break;
                case "supplierId":
                    // Perform filtering by supplierId
                    aFilteredListOfProducts = aListOfProducts.Where(p => p.SupplierId.ToString() == filterValue).ToList();
                    break;
                case "categoryId":
                    // Perform filtering by categoryId
                    aFilteredListOfProducts = aListOfProducts.Where(p => p.CategoryId.ToString() == filterValue).ToList();
                    break;
                default:
                    // Invalid filter criteria
                    aFilteredListOfProducts = new List<Products>();
                    break;
            }

            ViewBag.ListofProducts = aFilteredListOfProducts;

            return View("GetProducts");
        }





        public IActionResult UpdateAnOrderDetails(int orderId, int productId, double unitprice, int quantity, int discount)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateAnOrderDetail(orderId, productId, unitprice, quantity, discount);

            List<Orders> aListOfOrders = new List<Orders>();
            List<OrderDetails> aListOfOrderDetails = new List<OrderDetails>();
            List<Products> aListOfProducts = new List<Products>();
            ViewBag.ListOfOrders = aGateway.GetOrders();
            ViewBag.ListOfProducts = aGateway.GetProducts();
            ViewBag.ListOfOrderDetails = aGateway.GetOrderDetails();
            return View("GetOrderDetails");
        }

        public IActionResult UpdateAnOrderDetailsForm(int aProductId, int anOrderId)
        {
            DBGateway aGateway = new DBGateway();
            List<OrderDetails> aListOfOrderDetails = new List<OrderDetails>();
            List<Products> aListOfProducts = new List<Products>();

            aListOfProducts = aGateway.GetProductById(aProductId);
            aListOfOrderDetails = aGateway.GetOrderDetails();


            ViewBag.ListOfOrderDetails = aListOfOrderDetails;
            ViewBag.ListOfProducts = aListOfProducts;

            return View();
        }

        public IActionResult GetOrders()
        {
            DBGateway aGateway = new DBGateway();
            List<Orders> listOfOrders = aGateway.GetOrders();
            ViewBag.ListOfOrders = listOfOrders;
            return View();
        }
        public IActionResult GetOrderById(int anOrderId)
        {
            DBGateway aGateway = new DBGateway();
            List<Orders> listOfOrders = aGateway.GetOrdersById(anOrderId);
            ViewBag.ListOfOrders = listOfOrders;
            return View();
        }

        public IActionResult InsertOrderForm()
        {
            DBGateway aGateway = new DBGateway();

            //List<Customers> listOfCustomers = aGateway.GetCustomers(); 
            List<Employees> listOfEmployees = aGateway.GetEmployees();
            // List<Shippers> listOfShippers = aGateway.GetShippers();

            //ViewBag.ListOfCustomers = listOfCustomers;
            ViewBag.ListOfEmployees = listOfEmployees;
            //ViewBag.ListOfShippers = listOfShippers;

            return View();
        }

        public IActionResult InsertOrder(string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertOrder(customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);

            List<Orders> listOfOrders = aGateway.GetOrders();
            ViewBag.ListOfOrders = listOfOrders;

            return View("GetOrders");
        }

        public IActionResult UpdateOrderForm(int anOrderId)
        {
            DBGateway aGateway = new DBGateway();
            List<Orders> listOfOrders = aGateway.GetOrdersById(anOrderId);
            List<Employees> aListOfEmployees = aGateway.GetEmployees();

            ViewBag.ListOfOrders = listOfOrders;
            ViewBag.ListOfEmployees = aListOfEmployees;
            return View();
        }

        public IActionResult UpdateOrder(int orderId, string customerId, int employeeId, string orderDate, string requiredDate, string shippedDate, int shipVia, double freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateOrder(orderId, customerId, employeeId, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);

            List<Orders> listOfOrders = aGateway.GetOrders();
            ViewBag.ListOfOrders = listOfOrders;
            return View("GetOrders");
        }


        public IActionResult InsertOrderDetailsForm()
        {
            DBGateway aGateway = new DBGateway();
            List<Products> aListOfProducts = aGateway.GetProducts();
            List<Orders> aListOfOrders = aGateway.GetOrders();
            ViewBag.ListOfProducts = aListOfProducts;
            ViewBag.ListOfOrders = aListOfOrders;
            return View();
        }


        public IActionResult InsertOrderDetails(int orderId, int productId, double unitPrice, int quantity, int discount)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertOrderDetails(orderId, productId, unitPrice, quantity, discount);
            List<OrderDetails> listOfOrderDetails = aGateway.GetOrderDetails();
            ViewBag.ListOfOrderDetails = listOfOrderDetails;


            return View("GetOrderDetails");
        }




        
        public IActionResult GetShippers()
        {
            DBGateway aGateway = new DBGateway();
            List<Shippers> aListOfShippers = aGateway.GetShippers();

            ViewBag.ListOfShippers = aListOfShippers;
            return View();
        }

        //Written by Nebil
        public IActionResult GetShipperById(int aShipperId)
        {
            DBGateway aGateway = new DBGateway();

            Shippers shipper = aGateway.GetShipperById(aShipperId);

            ViewBag.Shipper = shipper;

            return View();
        }
        
        public IActionResult InsertShipper(int shipperId, string companyName, string phonenum)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.InsertShipper(shipperId, companyName, phonenum);

            List<Shippers> listOfShippers = aGateway.GetShippers();
            ViewBag.ListOfShippers = listOfShippers;

            return View("GetShippers");
        }
        public IActionResult InsertShipperForm()
        {
            return View();
        }
        public IActionResult UpdateShipperForm(int shipperId)
        {
            DBGateway aGateway = new DBGateway();
            Shippers shipper = aGateway.GetShipperById(shipperId);

            return View(shipper);
        }

        public IActionResult UpdateShipper(int shipperId, string companyName, string phonenum)
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

            return RedirectToAction("GetShippers", "Home");
        }


        public IActionResult UpdateACategoryForm(int aCategoryId)
        {
            DBGateway aGateway = new DBGateway();
            List<Categories> aListOfCategories = new List<Categories>();


            aListOfCategories = aGateway.GetCategoriesById(aCategoryId);



            ViewBag.ListOfCategories = aListOfCategories;

            return View();
        }




        public IActionResult UpdateACategory(int categoryId, string categoryName, string description)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateACategory(categoryId, categoryName, description);

            List<Categories> aListOfCategories = new List<Categories>();
            ViewBag.ListOfCategories = aGateway.GetCategories();
            return View("GetCategories");
        }

        public IActionResult GetCustomers()
        {
            DBGateway aGateway = new DBGateway();

            List<Customers> aListOfCustomers = aGateway.GetCustomers();

            ViewBag.ListofCustomers = aListOfCustomers;


            return View();
        }

        public IActionResult GetCustomerById(string aCustomerId)
        {
            DBGateway aGateway = new DBGateway();

            List<Customers> aListOfCustomers = aGateway.GetCustomerById(aCustomerId);

            ViewBag.ListOfCustomers = aListOfCustomers;

            return View();
        }


        public IActionResult InsertCustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            DBGateway aGateway = new DBGateway();

            aGateway.InsertCustomer(customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);

            List<Customers> listOfCustomers = aGateway.GetCustomers();

            ViewBag.ListOfCustomers = listOfCustomers;

            return View("GetCustomers");
        }

        public IActionResult InsertCustomerForm()
        {
            return View();
        }
        public IActionResult UpdateACustomer(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateACustomer(customerId, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);

            List<Customers> aListOfCustomers = new List<Customers>();
            ViewBag.ListOfCustomers = aGateway.GetCustomers();
            return View("GetCustomers");
        }
        public IActionResult UpdateACustomerForm(string aCustomerId)
        {
            DBGateway aGateway = new DBGateway();
            List<Customers> aListOfCustomers = new List<Customers>();

            aListOfCustomers = aGateway.GetCustomerById(aCustomerId);

            ViewBag.ListOfCustomers = aListOfCustomers;
            return View();
        }

        public IActionResult InsertSupplier(string companyName, string contactTitle, string address, string city, string contactName, string postalCode, string country, string phone, string fax)
        {

            DBGateway aGateway = new DBGateway();

            aGateway.InsertSupplier(companyName, contactTitle, address, city, contactName, country, phone, postalCode, fax);


            List<Suppliers> aListOfSuppliers = aGateway.GetSuppliers();

            ViewBag.ListOfSuppliers = aListOfSuppliers;

            return View("GetSuppliers");
        }

        public IActionResult InsertSuppliersForm()
        {
            return View();
        }
        public IActionResult UpdateSuppliers(int supplierId, string companyName, string contactTitle, string address, string city, string contactName, string postalCode, string country, string phone, string fax)
        {
            DBGateway aGateway = new DBGateway();
            aGateway.UpdateSupplier(supplierId, companyName, contactTitle, address, city, contactName, postalCode, country, phone, fax);

            List<Suppliers> listOfSuppliers = aGateway.GetSuppliers();
            ViewBag.ListOfSuppliers = listOfSuppliers;
            return View("GetSuppliers");
        }

        public IActionResult UpdateASupplierForm(int aSupplierId)
        {
            DBGateway aGateway = new DBGateway();
            List<Suppliers> listOfSuppliers = aGateway.GetSuppliersById(aSupplierId);

            ViewBag.ListOfSuppliers = listOfSuppliers;
            return View();

        }










        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
