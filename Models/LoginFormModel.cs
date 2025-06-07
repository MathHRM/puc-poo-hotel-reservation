using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Models
{
    public class LoginFormModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
