using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLab.Data {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, string username, string email)
        {
            Id = id;    
            Name = username;
            Email = email;
        }
        public User()
        {

        }

    }
}
