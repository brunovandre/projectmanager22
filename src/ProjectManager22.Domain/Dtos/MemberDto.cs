using System.ComponentModel.DataAnnotations;

namespace ProjectManager22.Domain.Dtos
{
    public class MemberDto
    {
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe um cargo.")]
        [Display(Name = "Cargo")]
        public string Atribuicao { get; set; }
    }
}
