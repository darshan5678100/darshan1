using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentService.exception
{
   public class LibraryException : Exception
    {
        public LibraryException() : base()
            {
            Console.WriteLine("OOppss something wents wrong!!");
            }
        public LibraryException(string Message) : base(Message)
        {
            Console.WriteLine("OOppss something wents wrong!!");
        }
        public LibraryException(string Message,Exception InnerException ) 
        {

        }
       
        static void Main(string[] args)
        {

        }
    }
}
