using ddl.Core.Entities;
using ddl.Core.Enums;
using ddl.Exceptions;
using ddl.Exceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ddl.Services.Controllers
{
    public static class UserServices
    {

        static void CrudMenu()
        {
            Console.WriteLine("1.Product Get All");
            Console.WriteLine("2.Add Product");
            Console.WriteLine("3.Order Upload");
            Console.WriteLine("4.Order Remove");
            Console.Write("Enter User Answer : ");
        }

        public static void CrudBasket()
        {
            User user = UserIdSearch();
            CrudMenu();
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    GetAll();
                    break;

                case 2:
                    ControllerServices.LoginController();
                    break;
                case 3:
                    CorrectUserType(user);
                    break;

                case 4:
                    RemoveUser(user);
                    break;

                default:
                    throw new InvalidChoiceException(ExceptionMessage.İnvalidChoiceMessage);
                    break;
            }
        }

        public static User UserIdSearch()
        {
            GetAll();
            Console.Write("Enter User Id : ");
            return GetUserById(Convert.ToInt32(Console.ReadLine()));
        }

        public static void Add(User value)
        {
            if (NullController(value) && UserSearch(value.Login) && UserPasswordController(value.Password))
                DataBase.users.Add(value);
            else
                throw new ExistingUserExceptions(ExceptionMessage.ExistingUserExceptionsMessage);
        }

        public static User SignIn(string login,string password)
        {
            if (!DataBase.users.Any(x => x.Login == login && x.Password == password))
                throw new InvalidUserNotFound(ExceptionMessage.InvalidUserNotFoundMessage);
            return DataBase.users.Find(x => x.Login == login && x.Password == password);
        }

        public static void GetAll()
        {
            DataBase.users.ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }

        public static User GetUserById(int id)
        {
            User user = DataBase.users.Find(x => x.Id == id);
            if(NullController(user))
                return user;
            return null;
        }

        public static bool UserAdminController(User user)
        {
            if (NullController(user))
              return GetUserById(user.Id).UserType == UserTypeEnum.Admin;
            return false;
        }

        public static void CorrectUserType(User value)
        {
            if (NullController(value))
                GetUserById(value.Id).UserType = UserType();
        }

        public static void RemoveUser(User value)
        {
            if (NullController(value))
                DataBase.users.Remove(GetUserById(value.Id));
        }

        static bool UserLoginController(string login)
        {
            if (login.Contains('@'))
                login = login.Split("@").First();
            
            bool loginController = login.Length > 3 && login.Length < 16;        
            return loginController ? loginController : throw new InvalidUserLoginException(ExceptionMessage.InvalidUserLoginMessage);
        }

        static bool UserPasswordController(string password)
        {
            Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,16}$");
            bool passwordController = regex.IsMatch(password);
            
            return passwordController ? passwordController : throw new InvalidUserPaswordException(ExceptionMessage.InvalidUserPasswordMessage);
        }
       
        public static bool NullController(User value)
        {
            return value != null ? true :
            throw new InvalidUserNotFound(ExceptionMessage.InvalidUserNotFoundMessage);
        }

        public static bool UserSearch(string login)
        {
          if(DataBase.users.Count != 0)
            return UserLoginController(login) && DataBase.users.Any(x=> x.Login != login);

            return UserLoginController(login);
        }

        static void UserTypeMenu()
        {
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.Member");
            Console.Write("Enter User Answer : ");
        }

        public static UserTypeEnum UserType()
        {
            UserTypeMenu();
            int userAnswer = Convert.ToInt32(Console.ReadLine());

            if (userAnswer > 3)
                throw new InvalidUserTypeEnumException(ExceptionMessage.InvalidUserTypeEnumMessage);

            return (UserTypeEnum)userAnswer;
        }
    }
}
