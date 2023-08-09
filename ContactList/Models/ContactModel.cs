using System.ComponentModel.DataAnnotations;

namespace ContactList.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do contato.")]
        [EmailAddress(ErrorMessage = "O formato de email enviado não é válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o telefone do contato.")]
        [Phone(ErrorMessage = "O formato de telefone enviado não é válido")]
        public string Phone { get; set; }
    }
}
