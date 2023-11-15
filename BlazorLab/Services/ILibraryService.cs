using BlazorLab.Data;

namespace BlazorLab.Services
{
    public interface ILibraryService
	{
		public void AddUser(User user);
		public void EditUser(string oldusername, string oldemail, string newname, string newemail);
		public void RemoveUser(string user);
		public void AddBook(Book book);
		public void EditBook(int ID, string newA, string newT, string newISBN);
		public void RemoveBook(string isbn);
		public void BorrowBook(int id, int userid);
		public void ReturnBook(int id, int userid);
		public List<User> ListUsers();
		public List<Book> ListBooks();
		public Dictionary<User, List<Book>> returnDictionary();

	}
}
