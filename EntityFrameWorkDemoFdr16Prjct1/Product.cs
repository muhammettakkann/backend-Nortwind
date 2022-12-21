using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkDemoFdr16Prjct1
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; } //ınt 16=smalInt

    }
}
