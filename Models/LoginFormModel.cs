using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Models
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
