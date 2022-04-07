using System;
using System.Collections.Generic;

namespace bookmanagementpkg
{
 public class InvalidBookIDException: Exception
  {
    public  InvalidBookIDException(string message)
      :base(message){
        Console.WriteLine("Custom Exception handling For Book ID \n" + message+"\n");
    }
  } // Exception for Book ID

  public class InvalidBookNameException: Exception
  {
    public  InvalidBookNameException(string message)
      :base(message){
        Console.WriteLine("Custom Exception handling For Book Name\n"+message+"\n");
    }
  } // Exception for Book Name

  public class Book
  {
    public int BookID;
    public String BookName;
    public int ISBNNo;
    public float Price;
    public String Publisher;
    public int NumPage;
    public String Language;
    public String LoT;
    public String Summary;

    public bool Add_book(){
          string[] LoTArray = {".NET", "Java", "IMS", "V&V", "BI", "RDBMS"};

          Console.WriteLine("Enter Book ID : ");

          try{
            BookID = Convert.ToInt32(Console.ReadLine());
            string bookID_str = Convert.ToString(BookID);
            if(bookID_str.Length != 5){
              throw new InvalidBookIDException("Sorry, Book ID must have length of 5");
            }
          }catch (FormatException){ // catch 1
            Console.WriteLine("Input is not an integer");
            return false;
          }catch(Exception){ // catch 2 custome exception
            return false;
          }
          Console.WriteLine("Enter Book Name");
          BookName = Console.ReadLine();
            try{
              if(BookName.Length < 1){
                throw (new InvalidBookNameException("Book Name cannot be empty"));
              }
            }catch(Exception){
                return false;
            }

          Console.WriteLine("Enter ISBN No");
          try{
            ISBNNo = int.Parse(Console.ReadLine());
          }catch (FormatException){
            Console.WriteLine("Input is not an integer");
            return false;
          }

          Console.WriteLine("Enter Price");
          try{
            Price = float.Parse(Console.ReadLine());
          }catch (FormatException){
            Console.WriteLine("Input is not an Double");
            return false;
          }

          Console.WriteLine("Enter Publisher");
          Publisher = Console.ReadLine();

          Console.WriteLine("Enter Page Numbers of book");
          try{
            NumPage = int.Parse(Console.ReadLine());
          }catch (FormatException){
            Console.WriteLine("Input is not an integer");
            return false;
          }

          Console.WriteLine("Enter Language");
          Language = Console.ReadLine();
          if(Language.Length == 0){
            Language = "English";
          }

          Console.WriteLine("Enter LoT within the list below");
          foreach(string s in LoTArray){
            Console.Write(s + "\t");
          }
          Console.WriteLine();

          LoT = Console.ReadLine();

          if(LoT.Length > 0){
            bool search_LoT =  Array.IndexOf(LoTArray, LoT) >= 0;
            if(!search_LoT){
              Console.WriteLine("Invalid LoT");
              return false;
            }
          }else{
            LoT = "Technical";
          }

          Console.WriteLine("Enter Summary");
          Summary = Console.ReadLine();

          return true;
    } // Method for Adding Book

    public void view_book(){
      Console.WriteLine("{0} \t {1} \t {2} \t\t {3} \t {4} \t {5} \t {6} \t {7} \t {8} ", this.BookID, this.BookName, this.ISBNNo, this.Price, this.Publisher, this.NumPage, this.Language, this.LoT, this.Summary);
    } // Method for View Book
  } // book class end

  public class Mainclass
  {
    public static void Main(string[] args)
    {
      bool flag = true;
      Dictionary<int, Book> B = new Dictionary<int, Book>();

      while (flag) {
        Console.WriteLine("Select Choice");
        Console.WriteLine(" 1. Add Book\n 2. View Book\n 3. Delete Book\n 4. Exit");
        int choice = int.Parse(Console.ReadLine());
        switch (choice) {

          case 1:
            Book NewBook = new Book();
            if(NewBook.Add_book()){
              B.Add(NewBook.BookID, NewBook);
            }
          break;

          case 2:
            if(B.Count > 0){
              Console.WriteLine("ID  \t BookName \t ISBN No \t Price \t Publisher \t Pages \t Language \t LoT \t Summary");
              foreach (KeyValuePair<int, Book>  BDic in B) {
                BDic.Value.view_book();
              }
            }else{
                Console.WriteLine("\nNo data Found in Book Directory\n");
            }
          break;

          case 3:
            Console.WriteLine("Enter Book Id to Delete");
            int DeleteID = 0;
            try{
              DeleteID = int.Parse(Console.ReadLine());
            }catch (FormatException){
              Console.WriteLine("Input is not an integer");
              break;
            }

            if(B.ContainsKey(DeleteID)){
              B.Remove(DeleteID);
            }else{
              Console.WriteLine("\nBook ID is not matched with Directory \n");
            }
          break;

          case 4:
            flag = false;
          break;
        } // switch end
      } // while end

    } // Main Method end
  } // MainClass end
} //Namespace End