using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSS.Models

{
    [Table("Servico")]
    public class Servico
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Escreva a data de início!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dtini { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Dtfim { get; set; } // Permite valores nulos



        [StringLength(500)]
        [Required(ErrorMessage = "Escreva a sua descrição!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [ForeignKey("Usuario")]
        [Display(Name = "Plano")]
        public int Usuario_Id { get; set; }
        public virtual Usuario? Usuario { get; set; }

        [ForeignKey("Tiposervico")]
        [Required(ErrorMessage = "Selecione o tipo do serviço")]
        [Display(Name = "Tipo usuário")]
        public int Tiposervico_Id { get; set; }
        public virtual Tiposervico? Tiposervico { get; set; }

        [ForeignKey("Status")]
        [Required(ErrorMessage = "Selecione o Status")]
        [Display(Name = "Status")]
        public int Status_Id { get; set; }
        public virtual Status? Status { get; set; }
    }
}
