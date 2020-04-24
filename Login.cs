using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentService.dml
{
   public class Login
    {
        public static string AdminUsername="admin";
        public static string AdminPassword="admin";
        public string Username;
        public string Password;
        public int BookId1;
        public int BookId2;
        public int BookId3;
        public Login(string name,string password)
        {
            Username = name;
            Password = password;
            
        }
    }
}
