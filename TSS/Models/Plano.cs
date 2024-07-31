using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSS.Models
{

    [Table("Plano")]

    public class Plano
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Escreva o nome do plano!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Escreva a descrição do plano!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Escreva o valor do plano!")]
        [Display(Name = "Preço")]
        public string Preco { get; set; }

        [ForeignKey("Tipoplano")]
        [Required(ErrorMessage = "Selecione o tipo de plano")]
        [Display(Name = "Tipo plano")]
        public int Tipoplano_Id { get; set; }
        public virtual Tipoplano? Tipoplano { get; set; }
    }

}