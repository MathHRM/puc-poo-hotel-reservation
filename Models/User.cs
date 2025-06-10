using backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Document { get; set; } 

    }
}

//matheus terminar o post para auth
//saulo vai 