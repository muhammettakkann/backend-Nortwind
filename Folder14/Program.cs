using System;
using System.Collections.Generic;
using System.Linq;

namespace Folder15
{
    class Program
    {
        //Konu: LinqProject
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Bilgisayar"},
                new Category{CategoryId=2, CategoryName="Telefon"},
                new Category{CategoryId=3, CategoryName="Tablet"},
            };
            List<Product> products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Acer Laptop", QuantityPerUnit="32 Gb Ram", UnitPrice=10000, UnitsInStock=5},
                new Product{ProductId=2, CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="16 Gb Ram", UnitPrice=8000, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=1, ProductName="Hp Laptop", QuantityPerUnit="8 Gb Ram", UnitPrice=6000, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Samsung Telefon", QuantityPerUnit="4 Gb Ram", UnitPrice=5000, UnitsInStock=15},
                new Product{ProductId=5, CategoryId=2, ProductName="Apple Telefon", QuantityPerUnit="4 Gb Ram", UnitPrice=8000, UnitsInStock=0},

            };
            //Ürünleri ekrana yazdırmak için çözüm üretiyoeruz.
            //Test(products);
            //AnyTest(products);
            //FindTest(products);
            //FindAllTest(products);
            //WhereTest1(products);
            //WhereTest2(products);
            //ClassicLinqTest(products);
            //JoinMetotTest   (categories, products);

        } 

        private static void JoinMetotTest(List<Category> categories, List<Product> products)
        {
            var result = from p in products
                         join c in categories //db deki join işlemini yapıyoruz.
                         on p.CategoryId equals c.CategoryId //hangi sütun ile hangi sütunun join olacağınu yazıyoruz.
                         where p.UnitPrice > 7000
                         orderby p.UnitPrice descending
                         select new ProductDto
                         {
                             ProductId = p.ProductId,
                             CategoryId = c.CategoryName,
                             ProductName = p.ProductName,
                             UnitPrice = p.UnitPrice
                         };
            foreach (var productDto in result)
            {
                //Console.WriteLine(productDto.ProductName+" "+ productDto.CategoryId);
                Console.WriteLine("{0} {1}", productDto.ProductName, productDto.CategoryId);
                //ekrana yazdırmak için de farklı kullanımları yazdım.
                //şuan çalışan kullanım daha yüksek performans sağlar.
            }
        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products //farklı bir kullanım tarzı
                         where p.UnitPrice > 6000
                         orderby p.UnitPrice descending, p.ProductName ascending //descendig yazmazsak ascendig çalışır.
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName); //. dan sonra artık sadece yukarıdaki 3 kriteri çekebiliyoruz.
            }
        }


        private static void WhereTest2(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice).ThenBy(p => p.ProductName);
            //yukarıdaki kod da order by ile artan fiyata göre içerisinde "top" bulunanları sıraladık. Aynı gelen fiyatta ise isme göre sıraladık.
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void WhereTest1(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice);
            //yukarıdaki kod da order by ile artan fiyata göre içerisinde "top" bulunanları sıraladık.
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top")); //içerisinde "top" geçen kelimeleri getir.
            Console.WriteLine(result.Count);
        }

        private static void FindTest(List<Product> products)
        {
            var result = products.Find(p => p.ProductId == 3); //aradığımız kritere uygun nesneyi döner.
            Console.WriteLine(result.ProductName); //Find ı nesnenin bir verisiyle döndürebiliriz.
        }

        private static void AnyTest(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Laptop");//any metotu "var mı?" şeklinde kullanılır.
            //result true dönecektir var ise, yoksa false döner.
            Console.WriteLine(result);
            
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("Algoritmik*****************");
            foreach (var product in products) //sağdaki veri yapmıza vermiş olduğumuz referans olacak
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                /*Ne kadar filtreleme uygularsak o kadar kısıtlama ortaya çıkıyor. 
                 * Dolayısıyla bizim bir Linq yapısına ihtiyacımız var.
                 */
                {
                    Console.WriteLine(product.ProductName);
                }

            }
            Console.WriteLine("Linq**************************");

            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3); //p=product ın kısaltılması
            /*1-)result adlı bir var oluşturduk.
             * 2-)products referansından sonra . ya tıklayıp mousle ok işaretli kutudan Where i seçtik
             * Bildiğim üzere where bir kısıtlama için kullanılabilir.
             * 3-)sonrasında products a bir harf olarak kısaltıp " => " kullanarak if şartlarını yazmaya başladık.
             */
            foreach (var p in result)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        static List<Product> GetProductsLinq(List<Product> products)
        { //fitrelemeye uyanları yeni bir diziye atıyor, bizim yazacağımız dizi oluştur aktar vb kendisi yapıyor.
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
            //to list kullanmamızın nedeni ise diziye atılmış veriyi listeye çekiyoruz.
        }
        
    }

    class ProductDto //dto=data tranfer opsition gibi bir şey
    {
        //ProductDto sayesinde sadece belli başlı verileri çekeceğimiz bir tablo oluşturduğumuz söylenebilir.
        public int ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

    }
    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }




}
