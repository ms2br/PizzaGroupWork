using ddl.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddl.Core.Entities
{
    public class User
    {
        static int id = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }

        public User(string name,string surName,string login,string password,UserTypeEnum userType)
        {
            Id = id++;
            Name = name;
            SurName = surName;
            Login = login;
            Password = password;
            UserType = userType;
        }

        public override string ToString()
        {
            return $"ID : {Id} Name : {Name} SurName : {SurName} UserType : {UserType}";
        }
    }
}
