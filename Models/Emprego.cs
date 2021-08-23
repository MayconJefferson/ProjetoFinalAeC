using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace projetoFinalAeC.Models
{
    [Table("Empregos")]
    public class Emprego
    {
        [Key]
        [Column("id")]
        public int Id {get; set;}

        [Column("desc_emprego", TypeName ="varchar")]
        [MaxLength(200)]
        [Required]
        public string Descricao{get; set;}
        
    }
}