using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentService.dml
{
 public class Book
    {
        public int BookId;
        public string BookName;
        public int Copies;
        public string Status;
        public DateTime Date;
        public string Author;

        public Book(int id,string name,int copies,string status,DateTime date,string author)
        {
            BookId = id;
            BookName = name;
            Copies = copies;
            Status = status;
            Date = date;
            Author = author;
        }
    }
}
