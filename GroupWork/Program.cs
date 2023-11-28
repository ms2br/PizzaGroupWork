using ddl.Core.Entities;
using ddl.Services.Controllers;

namespace GroupWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataBase.products.Add(new Product("Asas", 12));
            DataBase.products.Add(new Product("llll", 22));
            DataBase.products.Add(new Product("ffff", 20));
            DataBase.products.Add(new Product("ssss", 21));
            string controller = string.Empty;            
            do
            {
                try
                {
                    User user = ControllerServices.User;
                    if (user == null)
                    {
                        ControllerServices.LoginController();
                        continue;
                    }
                    ControllerServices.BasketMenuController();                   
                    Console.WriteLine("Program Exit (Y) => Yes => : ");
                    controller = Console.ReadLine().ToUpper();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (controller != "Y");
                    
        }
    }
}