using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Core.Entities
{
    public class Basket
    {
        static int id = 1;
        public DateTime dateTime { get; } = DateTime.Now;
        public int Id { get; }
        public float TotalPrice { get; }
        public User User { get; set; }
        public Product Product { get; set; }
        public string UserDeliveryAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public byte OrderCount { get; set; } = 1;

        public Basket(User user,Product product,string userDeliveryAddress,string userPhoneNumber,byte orderCount)
        {
            Id = id++;
            User = user;
            Product = product;
            UserDeliveryAddress = userDeliveryAddress;
            UserPhoneNumber = userPhoneNumber;
            OrderCount = orderCount;
            TotalPrice = orderCount * product.Price;
        }


        public override string ToString()
        {
            return $"{Id} {User.Name} {User.SurName} {Product.Name} {UserDeliveryAddress} {UserPhoneNumber} {OrderCount}";
        }
    }
}
