using System.Collections.Generic;
using System.Text.Json;
using BlazorLab.Data;
using BlazorLab.Pages;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace BlazorLab.Services 
{
	public class LibraryService : ILibraryService 
	{

        public List<Book> books { get; set; } = new List<Book>();
        public List<User> users { get; set; } = new List<User>();
       public Dictionary<User, List<Book>> borrowedBooks { get; set; } = new Dictionary<User, List<Book>>();
		//i think errors need to be handled in the blazor code (in the code for each individual page
		User user1 = new User(1, "sydnie", "sydnie@gmail.com");
		User user2 = new User(2, "bob", "bob@gmail.com");
		User user3 = new User(3, "sally", "sally@gmail.com");
		User user4 = new User(4, "joe", "joe@gmail.com");
        public int idCount = 0;
       
		public LibraryService()
		{
            users.Add(user1);
            users.Add(user2);   
            users.Add(user3);
            users.Add(user4);
		}

		public void AddUser(User user) 
		{
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
			users.Add(user);
		}

        public void RemoveUser(string email)
        {

            try
            {
                users.RemoveAll(s => s.Email == email);
			}
			catch { }
        }
        public void EditUser(string oldusername, string oldemail, string newname, string newemail)
        {
            var index = users.FindIndex(u => u.Email == oldemail && u.Name == oldusername);
            User temp = users[index];
            temp.Email = newemail;
            temp.Name = newname;
            users[index] = temp;
		}
        public void AddBook(Book book) 
		{ 
            book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
			books.Add(book);

		}


		public void EditBook(int ID, string newA, string newT, string newISBN)
		{
            var index = books.FindIndex(u => u.Id == ID);
			Book temp = books[index];
			temp.Title = newT;
			temp.Author = newA;
            temp.ISBN = newISBN;
            temp.Id = ID;
			books[index] = temp;
		}
		public void RemoveBook(string isbn)
		{
			try
			{
				var index = books.FindIndex(b => b.ISBN == isbn);
                books.Remove(books[index]);
			}
			catch
			{
			}
		}
        public void BorrowBook(int id , int userid) 
		{
            User user = users.Find(u => u.Id == userid);
            Book book = books.Find(b => b.Id == id);
            if (borrowedBooks.ContainsKey(user) && books.Contains(book))
            {
                List<Book> list = borrowedBooks[user];
                if (list.Contains(book) == false)
                {
                    list.Add(book);
                    books.Remove(book);
                }
            }
            else if (books.Contains(book))
            {
                List<Book> list = new List<Book>();
                list.Add(book);
                borrowedBooks.Add(user, list);
                books.Remove(book);
            }
        }


		public void ReturnBook(int id, int userid)
		{
			User user = users.Find(u => u.Id == userid);
			Book bookToReturn = borrowedBooks[user][id - 1];

			borrowedBooks[user].RemoveAt(id - 1);
			books.Add(bookToReturn);
		}

        public List<User> ListUsers()
        {
            return users;
        }

		public List<Book> ListBooks()
		{
            return books;
		}

        public Dictionary<User, List<Book>> returnDictionary() 
        {
            return borrowedBooks;
        }
	}
}
