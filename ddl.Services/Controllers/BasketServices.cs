using ddl.Core.Entities;
using ddl.Exceptions.Exceptions;
using ddl.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ddl.Services.Controllers
{
    public static class BasketServices
    {
        public static void CrudBasket()
        {
            Basket basket = BasketIdSearch();
            CrudMenu();
            int answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    GetAllBasket();
                    break;

                case 2:
                    UploadBasket(basket);
                    break;

                case 3:
                    RemoveOrder(basket);
                    break;

                default:
                    throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                    break;
            }
        }
      
        public static void Add(Basket order)
        {
            if (NullController(order) && UserPhoneNumberController(order.UserPhoneNumber))
                DataBase.basket.Add(order);
        }

        public static void UploadBasketMenu()
        {
            Console.WriteLine("1.Upload Basket Order");
            Console.WriteLine("2.Upload User Delivery Address");
            Console.WriteLine("3.Upload User Phone Number");
            Console.WriteLine("4.Upload Basket Product Count");
            Console.Write("Enter User Answer :  ");
        }

        public static Basket BasketIdSearch()
        {
            GetAllBasket();
            Console.Write("Enter Basket Id : ");
            return GetBasketById(Convert.ToInt32(Console.ReadLine()));
        }

        public static Basket GetBasketById(int id)
        {
            Basket basket = DataBase.basket.FirstOrDefault(x => x.Id == id);
            return NullController(basket) ? basket : null;
        }

        public static Basket GetBasketByUserId(int id)
        {
            Basket basket = DataBase.basket.FirstOrDefault(x => x.User.Id == id);
            return NullController(basket) ? basket : null;
        }

        public static Basket GetBasketByProductId(int id)
        {
            Basket order = DataBase.basket.FirstOrDefault(x => x.Product.Id == id);
            return NullController(order) ? order : null;
        }

        public static void GetAllBasket()
        {
            DataBase.basket.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public static void GetAllUserOrder(Basket basket)
        {
            bool nullController = NullController(basket);
            if (nullController && DataBase.basket.Any(x => x.User.Id == basket.User.Id))
                Console.WriteLine(GetBasketByUserId(basket.User.Id));
            else if (nullController && DataBase.basket.Count == 0)
                Console.WriteLine(GetBasketByUserId(basket.User.Id));
        }

        public static void RemoveOrder(Basket basket)
        {
            if(NullController(basket))
                DataBase.basket.Remove(GetBasketByUserId(basket.Id));
        }

        public static void UploadBasket(Basket basket)
        {
            basket = GetBasketById(basket.Id);
            if (NullController(basket))
            {
                UploadBasketMenu();
                int answer = Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        UploadBasketOrder(basket);
                        break;
                    case 2:
                        UploadUserDeliveryAddress(basket);
                        break;
                    case 3:
                        UploadUserPhoneNumber(basket);
                        break;
                    case 4:
                        UploadBasketProductCount(basket);
                        break;
                    default:
                        throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                        break;
                }

            }
        }

        public static bool UserPhoneNumberController(string userPhoneNumber)
        {
            Regex regex = new Regex(@"^\+994[-\s]?[0-9]{3}[-\s]?[0-9]{2}[-\s]?[0-9]{2}[-\s]?[0-9]{2}$");
            return regex.IsMatch(userPhoneNumber) ? true : throw new InvalidUserPhoneNumberException(ExceptionMessage.InvalidUserPhoneNumberMessage);
        }

        static void CrudMenu()
        {
            Console.WriteLine("1.Basket Get All");
            Console.WriteLine("2.Order Upload");
            Console.WriteLine("3.Order Remove");
            Console.Write("Enter User Answer : ");
        }

        static bool NullController(Basket order)
        {
            return order != null ? true :
            throw new InvalidBasketProductsNotFound(ExceptionMessage.InvalidBoxNotFoundMessage);
        }
      
        static void UploadBasketProductCount(Basket basket)
        {
            if (NullController(basket))
            {
                Console.Write("Enter Order Count : ");
                basket.OrderCount = Convert.ToByte(Console.ReadLine());
            }

        }

        static void UploadBasketOrder(Basket basket)
        {
            if (NullController(basket))
            {
                ProductServices.GetAll();
                Console.Write("Enter Product Id : ");
                basket.Product = ProductServices.GetProductById(Convert.ToInt32(Console.ReadLine()));
            }
        }

        static void UploadUserDeliveryAddress(Basket basket)
        {
            if (NullController(basket))
            {
                Console.Write("Enter New User Delivery Address : ");
                basket.UserDeliveryAddress = Console.ReadLine();
            }
        }

        static void UploadUserPhoneNumber(Basket basket)
        {
            if (NullController(basket))
            {
                Console.Write("Enter New User Phone Number : ");
                basket.UserPhoneNumber = Console.ReadLine();
            }
        }   
    }
}
