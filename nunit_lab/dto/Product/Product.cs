using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_lab.dto.Product
{
    internal class Product
    {
        public string ProductName = "Product1";
        public string CategoryId = "Dairy Products";
        public string SupplierId = "Exotic Liquids";
        public string UnitPrice = "10";
        public string QuantityPerUnit = "1 box";
        public string UnitsInStock = "6";
        public string UnitsOnOrder = "3";
        public string ReorderLevel = "0";

        public Product(string ProductName, string CategoryId, string SupplierId, string UnitPrice, string QuantityPerUnit, string UnitsInStock, string UnitsOnOrder, string ReorderLevel)
        {

            this.ProductName = ProductName;
            this.CategoryId = CategoryId;
            this.SupplierId = SupplierId;
            this.UnitPrice = UnitPrice;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitsInStock = UnitsInStock;
            this.UnitsOnOrder = UnitsOnOrder;
            this.ReorderLevel = ReorderLevel;
        }
    
    }
}
