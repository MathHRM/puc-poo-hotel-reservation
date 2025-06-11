using backend.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome de usuário é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome de usuário deve ter entre 3 e 50 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

<<<<<<< HEAD
        public string Document { get; set; }
        public ICollection<RoomReservation> Reservations { get; set; }
=======
        [Required(ErrorMessage = "Documento é obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Documento inválido")]
        public string Document { get; set; }
>>>>>>> main
    }
}

