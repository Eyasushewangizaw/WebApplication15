using System.Runtime.CompilerServices;



namespace WebApplication15.Models
{
    public class Categories
    {
        private int categoryId = -1;
        private string categoryName = "n/a";
        private string description = "Description";

        public int CategoryId
        {
            get
            {
                return this.categoryId;
            }
            set
            {
                this.categoryId = value;
            }
        }


        public string CategoryName
        {
            get { return this.categoryName; }
            set { this.categoryName = value; }

        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }


        public Categories() : this(-1, "n/a", "n/a")
        {

        }

        public Categories(string categoryName) : this(-1, categoryName, "n/a")
        {

        }


        public Categories(int categoryId, string categoryName, string description)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
        }
    }
}