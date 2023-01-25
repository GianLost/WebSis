using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSis.Models
{
    public class Users
    {
        public static int ADMIN = 1;

        public static int PADRAO = 0;

        [Key, Required(ErrorMessage = "O campo Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório"), StringLength(80)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Login é obrigatório"), StringLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório"), StringLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório"), StringLength(50)]
        public string CheckedPassword { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        public int Type { get; set; }

        [ForeignKey("SecretariesId")]
        public int SecretariesId { get; set; }
        public Secretaries Secretaries { get; set; }
    }
}