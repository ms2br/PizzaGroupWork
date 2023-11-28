using ddl.Core.Entities;
using ddl.Exceptions.Exceptions;
using ddl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class ProductServices
    {

        static void CrudMenu()
        {
            Console.WriteLine("1.Product Get All");
            Console.WriteLine("2.Add Product");
            Console.WriteLine("3.Order Upload");
            Console.WriteLine("4.Order Remove");
            Console.Write("Enter User Answer : ");
        }

        public static void UploadProductMenu()
        {
            Console.WriteLine("1.Product Name");
            Console.WriteLine("2.Product Price");
            Console.Write("Enter User Answer : ");
        }

        public static void CrudBasket()
        {
            CrudMenu();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    GetAll();
                    break;

                case 2:
                    Add();
                    break;
                case 3:
                    Product product = ProductIdSearch();
                    UploadProductController(product);
                    break;

                case 4:
                    product = ProductIdSearch();
                    RemoveProduct(product);
                    break;

                default:
                    throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                    break;
            }
        }

        public static Product ProductIdSearch()
        {
            GetAll();
            Console.Write("Enter Product Id : ");
            return GetProductById(Convert.ToInt32(Console.ReadLine()));
        }

        public static void Add()
        {
            Console.Write("Enter Pizza Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Pizza Price : ");
            float price = Convert.ToSingle(Console.ReadLine());
            
            DataBase.products.Add(new Product(name, price));
        }

        public static Product GetProductById(int id)
        {
            Product product = DataBase.products.Find(x => x.Id == id);
            return NullContoller(product) ? product : null; 
        }

        public static void UploadProductController(Product product)
        {
            if (NullContoller(product))
            {
                product = GetProductById(product.Id);
                UploadProductMenu();
                int answer = Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        UpdateProductName(product);
                        break;
                    case 2:
                        UpdateProductPrice(product);
                        break;
                    default:
                        throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                        break;
                }

            }
        }

        public static void RemoveProduct(Product product)
        {
            if (NullContoller(product))
                DataBase.products.Remove(GetProductById(product.Id));
        }

        public static void GetAll()
        {
            DataBase.products.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public static bool NullContoller(Product product)
        {
            return product != null ? true :
            throw new InvalidProductNotFoundException(ExceptionMessage.InvalidProductNotFoundMessage);
        }

        static void UpdateProductName(Product product)
        {
            if (NullContoller(product))
            {
                Console.Write("Enter Name : ");
                product.Name = Console.ReadLine();
            }
        }

        static void UpdateProductPrice(Product product)
        {
            if (NullContoller(product))
            {
                Console.WriteLine("Enter Price : ");
                product.Price = Convert.ToSingle(Console.ReadLine());
            }
        }

    }
}
