using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagmentService.dml
{
  public  class DataModelLayer
    {
        static List<Login> UserList = new List<Login>();
        static List<Book> BookList = new List<Book>();
    public  static List<Book> RequestedBook= new List<Book>();

        //login admin
        public  bool Admin(string Username,string Password)
        {
            if (Username == Login.AdminUsername && Password == Login.AdminPassword)
                return true;
            else
                return false;
        }

        //admin login
        public  bool User(string Username,string Password)
        {
            bool UserLogin = false;
            foreach (var user in UserList)
            {
                 if(user.Username==Username && user.Password==Password)
                {
                   UserLogin=true;
                    return UserLogin;
                }
            }
            return UserLogin;
        }

        //add book
        public  bool AddBook(int id,string name,int copies,string status,DateTime date,string author)
        { 
             BookList.Add(new Book(id, name, copies, status, date, author));
                 return true;
      
        }
        //search book
        public Book Search(int id)
        {
            return  BookList.Find(a => a.BookId == id);
        }
        //display all book
        public List<Book> DisplayAll()
        {
            return BookList;
        }
        //remove book
        public bool RemoveBook(int id)
        {
            Book BookList1 = BookList.Find(a => a.BookId == id);
            BookList.Remove(BookList1);
            if (BookList1 == null)
            {
                return false;
            }
            return true;
        }
        //to update book
        public bool Update(int id,string value,string value1)
        {
            Book BookList1 = BookList.Find(a => a.BookId == id);
            if(value=="bookname")
            {
                BookList1.BookName = value1;
                return true;
            }
            else if(value=="copies")
            {
                BookList1.Copies = int.Parse(value1);
                return true;
            }
            else if(value=="status")
            {
                BookList1.Status = value1;
                return true;
            }
            else if(value=="date")
            {
                BookList1.Date = DateTime.Parse(value1);
                return true;
            }
            else if(value=="author")
            {
                BookList1.Author = value1;
                return true;
            }
            return false;
        }
        //add user
        public bool Adduser(string UserName,string Password)
        {
            UserList.Add(new Login(UserName, Password));
            return true;
        }
        //request by user
        public bool RequestBook(int id1,int id2,int id3,string User)
        {
            Login Book1 = UserList.Find(a => a.Username == User);
            if (id1 != 0)
            {
                Book1.BookId1 = id1;
                Book BookList1 = BookList.Find(a => a.BookId == id1);
                if (id2 != 0)
                {
                    Book1.BookId2 = id2;
                    Book BookList2 = BookList.Find(a => a.BookId == id2);
                    if (id3 != 0)
                    {
                        Book1.BookId3 = id3;
                        Book BookList3 = BookList.Find(a => a.BookId == id3);
                        RequestedBook.Add(BookList1);
                        RequestedBook.Add(BookList2);
                        RequestedBook.Add(BookList3);
                    }
                }
            }
            return true;
        }
        //issue book by admin
         public List<Book> Issue(int id1,int id2,int id3,string User)
        {
            Login Book1 = UserList.Find(a => a.Username == User);
            int count = 0;
            List<Book> book11 = new List<Book>();
            Book book1 = BookList.Find(a => a.BookId == id1);
            book11.Add(book1);
            Book1.BookId1 = id1;
            Book1.BookId2 = id2;
            Book1.BookId3 = id3;
            count++;
            if (id2 != 0)
            {
                Book book2 = BookList.Find(a => a.BookId == id2);
                book11.Add(book2);
                count++;
            }
            if (id3 != 0)
            {
                Book book3 = BookList.Find(a => a.BookId == id3);
                book11.Add(book3);
                count++;
            }
            return book11;
        }
        //to display issued book
        public List<Book> Transcaton(string User)
        {
            int count = 0;
            List<Book> book11 = new List<Book>();
            Login Book1 = UserList.Find(a => a.Username == User);
            if (Book1.BookId1 != 0)
            {
                Book book1 = BookList.Find(a => a.BookId == Book1.BookId1);
                book11.Add(book1);
                count++;
            }
            if (Book1.BookId2 != 0)
            {
                Book book2 = BookList.Find(a => a.BookId == Book1.BookId2);
                book11.Add(book2);
                count++;
            }
            if (Book1.BookId3 != 0)
            {
                Book book3 = BookList.Find(a => a.BookId == Book1.BookId3);
                book11.Add(book3);
                count++;
            }
            return book11;

        }



        static void Main(string[] args)
        {
        }
    }
}
