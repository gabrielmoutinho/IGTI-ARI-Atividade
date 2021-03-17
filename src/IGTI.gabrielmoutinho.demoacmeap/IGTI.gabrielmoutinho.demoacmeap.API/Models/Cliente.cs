using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public long Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        [Column("Data_Nascimento")]
        public DateTime DataNascimento { get; set; }
        [ForeignKey("Id_Endereco")]
        public Endereco Endereco { get; set; }
        public IEnumerable<Instalacao> Instalacao { get; set; }
    }
}
