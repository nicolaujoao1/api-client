using System.ComponentModel.DataAnnotations;

namespace API_CLIENT.Requests
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        [MaxLength(200)]
        public string Email { get; set; } = default!;
    }
}
