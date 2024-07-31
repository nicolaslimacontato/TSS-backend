using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Adicione isso para List<T>

namespace TSS.Models
{

    [Table("Usuario")]

    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Escreva o seu nome!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Escreva o seu email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Escreva a sua senha!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Escreva a sua data de nascimento!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dtnasc { get; set; }


        [StringLength(18)]
        [Required(ErrorMessage = "Escreva o seu CPF ou o seu CNPJ!")]
        [Display(Name = "CPF/CNPJ")]
        public string CPF_CNPJ { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "Escreva o seu Telefone!")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [ForeignKey("Tipousuario")]
        [Required(ErrorMessage = "Selecione o tipo do usuário")]
        [Display(Name = "Tipo usuário")]
        public int Tipousuario_Id { get; set; }
        public virtual Tipousuario? Tipousuario { get; set; }

        [ForeignKey("Plano")]
        [Required(ErrorMessage = "Selecione o plano")]
        [Display(Name = "Plano")]
        public int Plano_Id { get; set; }
        public virtual Plano? Plano { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>(); // Inicialize a coleção

    }
}