using System;
using System.Linq;

namespace EntityFrameWorkDemoFdr16Prjct1
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAll();
            GetProductsByCategory(1);
        }

        private static void GetAll()
        {
            NorthwindContext northwindContext = new NorthwindContext();

            foreach (var product in northwindContext.Products)
            {
                Console.WriteLine(product.ProductName);
            }
        }
       
    }
}
