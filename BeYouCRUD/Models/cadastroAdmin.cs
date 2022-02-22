using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeYouCRUD.Models
{
    [Table("cadastroAdmin")]
    public class cadastroAdmin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string nome_admin { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string telefone { get; set; }
        [Required]
        public string senha { get; set; }
    }
}