using System.ComponentModel.DataAnnotations;

namespace WebSis.Models
{
    public class Secretaries
    {

        [Key, Required(ErrorMessage = "O campo Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório"), StringLength(80)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Sigla é obrigatório"), StringLength(15)]
        public string Acronym { get; set; }

        /*[Required(ErrorMessage = "O campo Id do Usuário é obrigatório")]
        public int UsersId { get; set; }

        public Users Users { get; set; }*/

    }
}