using ddl.Core.Entities;
using ddl.Core.Enums;
using ddl.Exceptions;
using ddl.Exceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class ControllerServices
    {
        public static User User { get; private set; }
        public static bool userMenuController = true;

        #region User
        public static void LoginController()
        {
            LoginMenu();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    UserSignIn();
                    break;
                case 2:
                    CreateUser();
                    break;
                default:
                    throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                    break;
            }
        }

        static void LoginMenu()
        {
            Console.WriteLine("1.Sing In");
            Console.WriteLine("2.Sing Up");
            Console.Write("Enter User Answer : ");
        }

        static void CreateUser()
        {
            Console.Write("Enter User Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter User Sur Name : ");
            string surName = Console.ReadLine();

            Console.Write("Enter UserName or Email : ");
            string login = Console.ReadLine();

            Console.Write("Enter User PassWord : ");
            string password = Console.ReadLine();

            UserServices.Add(new User(name, surName, login, password, UserServices.UserType()));
        }

        static void UserSignIn()
        {
            Console.Write("Enter UserName or Email : ");
            string login = Console.ReadLine();

            Console.Write("Enter User PassWord : ");
            string password = Console.ReadLine();

            User = UserServices.SignIn(login, password);

            Console.WriteLine($"Xos Geldiniz {User.Name} {User.SurName}");
        }

        public static void MemberCommand()
        {
            UserMenuMembers();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    ProductOrder();
                    break;

                case 2:
                    CreateOrder(ProductAddBasket());
                    break;
                case 3:
                    User = null;
                    break;
                default:
                    throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                    break;
            }
        }

        static void UserMenuMembers()
        {
            Console.WriteLine("1.Pizzalara Bax.");
            Console.WriteLine("2.Sifaris ver");
            Console.WriteLine("3.Exit");
            Console.Write("Enter User Answer : ");
        }


        #endregion

        #region Admin User
        static void UserMenuAdmins()
        {
            Console.WriteLine("1.Pizzalara Bax.");
            Console.WriteLine("2.Sifaris ver");
            Console.WriteLine("3.Pizzalar");
            Console.WriteLine("4.Userler");
            Console.WriteLine("5.Crud");
            Console.WriteLine("6.Exit");
            Console.Write("Enter User Answer : ");
        }

        public static void AdminCommand()
        {
            UserMenuAdmins();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    ProductOrder();
                    break;

                case 2:
                    CreateOrder(ProductAddBasket());
                    break;

                case 3:
                    ProductServices.GetAll();
                    break;

                case 4:
                    UserServices.GetAll();
                    break;
                
                case 5:
                    Crud();
                    break;

                case 6:
                    User = null;
                    break;
                
                default:
                    throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                    break;
            }
        }
        #endregion


        #region Admin Baseket

        public static void ProductOrder()
        {
            Product product = ProductAddBasket();
            bool controller = true;
            
            if (!userMenuController)
            {
                BasketMenuController();
                return;
            }
            
            do
            {
                Console.WriteLine("1.Pressing the S button adds the pizza to the cart.");
                Console.WriteLine("2.When you press the G button, the Products menu is called.");
                Console.Write("Enter Value (S/G) : ");
                string answer = Console.ReadLine().ToUpper();
                switch (answer)
                {
                    case "S":
                        CreateOrder(product);
                        break;

                    case "G":
                        ProductServices.GetAll();
                        break;

                    default:
                        controller = false;
                        throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                        break;
                }
            } while (!controller);
        }

        static Product ProductAddBasket()
        {
            ProductServices.GetAll();
            Console.Write("Enter Product Id : ");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == 0)
            {
                userMenuController = false;
                return null;
            }
            userMenuController = true;
           return ProductServices.GetProductById(answer);
        }

        static byte PizzaCount()
        {
            Console.Write("Enter Pizza Count : ");
            byte count = Convert.ToByte(Console.ReadLine());
            return count;
        }

        static void TotalPrice(Product product,int pizzaCount)
        {
            if (product != null)
            {
                Console.WriteLine($"Total Price : {pizzaCount * product.Price}");
            }
        }

        static void CreateOrder(Product product)
        {
            if (!userMenuController)
            {
                BasketMenuController();
                return;
            }
            byte count = PizzaCount();
            TotalPrice(product,count);

            Console.Write("Enter User Delivery Address : ");
            string userDeliveryAddress = Console.ReadLine();

            Console.Write("Enter User Phone Number : ");
            string userPhoneNumber = Console.ReadLine();

            BasketServices.Add(new Basket(User, product, userDeliveryAddress, userPhoneNumber, count));
        }
        #endregion

        public static void BasketMenuController()
        {
            if (!UserServices.UserAdminController(User))
            {
                MemberCommand();
            }
            else if (User !=null)
            {
                AdminCommand();
            }
        }

        static void BasketCrudMenus()
        {
            Console.WriteLine("1.User Crud");
            Console.WriteLine("2.Product Crud");
            Console.WriteLine("3.Basket Crud");
            Console.Write("Enter User Answer : ");
        }

        public static void Crud()
        {
            if (UserServices.UserAdminController(User))
            {
                BasketCrudMenus();
                int answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        UserServices.CrudBasket();
                        break;
                    case 2:
                        ProductServices.CrudBasket();
                        break;
                    case 3:
                        BasketServices.CrudBasket();
                        break;
                    default:
                        throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                        break;
                }
            }      
        }
    }
}
