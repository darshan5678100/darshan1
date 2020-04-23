using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentService.dml;
using LibraryManagmentService.exception;

namespace LibraryManagmentService.bll
{
    public class BusinessLogicLayer
    {
      static  DataModelLayer Data = new DataModelLayer();
        //to check string having character or not
        public  bool Check(string Name)
        {
            bool Validation =true;
            char[] name = Name.ToCharArray();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= 'a' && name[i] <= 'z' || name[i] >= 'A' && name[i] <= 'Z')
                {
                    Validation = true;
                }
                else
                {
                    Validation = false;
                    break;
                }
            }
                if (Validation)
                {
                    return Validation;
                }
                else
                    return Validation;   
        }

        //password validation
        public  bool Password(string Password)
        {
            int LowerCase = 0;
            int UpperCase = 0;
            int SpecialCharacter = 0;
            char[] name = Password.ToCharArray();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] >= 'a' && name[i] <= 'z')
                {
                    LowerCase++;
                }
                else if (name[i] >= 'A' && name[i] <= 'Z')
                {
                    UpperCase++;
                }
                else if (!(name[i] >= 'a' && name[i] <= 'z') && !(name[i] >= 'A' && name[i] <= 'Z') && !(name[i] >= '0' && name[i] <= '9'))
                {
                    SpecialCharacter++;
                }
            }
            if (LowerCase > 4 && UpperCase > 0 && SpecialCharacter > 0)
            {
                return true;
            }
                return false;
        }
        
        //admin login
            public  bool Admin(string Username,string Password)
        {
            if(Check(Username) && Password.Length>4 && Password.Length<15)
            {
                return Data.Admin(Username, Password);
            }
            return false;
        }

        //user login
        public  bool User(string Username,string Password)
        {
            if(Check(Username) && Password.Length>6 && Password.Length<15 && this.Password(Password))
            {
                return Data.User(Username, Password);
            }
            return false;
        }

        //user validation
        public bool CheckUser(string Username,string Password)
        {
            if (Check(Username) && Password.Length > 6 && Password.Length < 15 && this.Password(Password))
            {
                return true;
            }
            return false;
        }

        // add book
        public  void AddBook(int id,string name,int copies,string status,DateTime date,string author)
        {
            if (id > 0 && id < 100)
            {
                if (Check(name) && Check(author) && name.Length>2 && name.Length<15 && author.Length>2 && author.Length<15)
                {
                    if (copies > 0 && copies < 200)
                    {
                        if (status.Equals("new") || status.Equals("old"))
                        {
                            Data.AddBook(id, name, copies, status, date, author);
                        }
                        else
                            throw new LibraryException("enter  valid status");
                    }
                    else
                        throw new LibraryException("enter valid copies");
                }
                else
                    throw new LibraryException("enter valid bookname or author name");
            }
            else
                throw new LibraryException("enter valid book id");
        }

        //remove book
        public bool bookRemove(int id)
        {
            if(id>0 && id<100)
            {
     return  Data.RemoveBook(id);
            }
            return false;
        }

        //search book
        public Book Search(int id)
        {
            if(id>0 && id<101)
            {
                return Data.Search( id);
            }
            return null;
        }

        //display all book
        public List<Book> DisplayAll()
        {
            return Data.DisplayAll();
        }

        //to update book
        public bool UpdateBook(int id,string value,string value1)
        {
            if(id>0 && id<101)
            {
                if(Check(value) && value.Length>0)
                {
                    if (value == "bookname")
                    {
                        if (Check(value1) && value1.Length > 0 && value1.Length < 15)
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid book name");
                            return false;
                        }
                    }
                    else if (value == "copies")
                    {
                        int copies = int.Parse(value1);
                        if (copies > 0 && copies < 200)
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid copies");
                            return false;
                        }
                    }
                    else if (value == "status")
                    {
                        if (value1 == "new" || value1 == "old")
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid status");
                        }
                    }
                    else if (value == "author")
                    {
                        if (Check(value1))
                        {
                            Data.Update(id, value, value1);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("enter valid author name");
                            return false;
                    }
                    }
                    else
                    {
                        Console.WriteLine("enter valid column name");
                    }
                    
                }
            }
            return false;
        }

        //add user by admin
        public bool Adduser(string Username,string Password)
        {
            if(Check(Username) && this.Password(Password))
            {
            return  Data.Adduser(Username, Password);
            }
            return false;
        }

    
        //user requsting book
        public bool RequestBook(int id1,int id2,int id3,string bookname)
        {
            if (id1 > 0 && id1 < 20 && id2 >=0 && id2 < 20 && id3 >=0 && id3 <20)
            {
                Data.RequestBook(id1, id2, id3,bookname);
                return true;
            }
            else
            {
                Console.WriteLine("book id not present");
            }
            return false;
        }

        //issue book by admin
        public List<Book> IssueBook(int id1,int id2,int id3,string user)
        {
            return Data.Issue(id1, id2, id3,user);
        }

        //to display book
        public List<Book> Transcation(string username)
        {
            return Data.Transcaton(username);
        }



        static void Main(string[] args)
        {
        }
    }
}
