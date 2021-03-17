using System.ComponentModel.DataAnnotations.Schema;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        public long Id { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string UF { get; set; }
    }
}
