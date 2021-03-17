using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Models
{
    [Table("Instalacao")]
    public class Instalacao
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        [Column("Data_Instalacao")]
        public DateTime DataInstalacao { get; set; }
        [ForeignKey("Id_Cliente")]
        public Cliente Cliente { get; set; }
        [ForeignKey("Id_Endereco")]
        public Endereco Endereco { get; set; }
        public IEnumerable<Fatura> Fatura { get; set; }
    }
}
