using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Models
{
    [Table("Fatura")]
    public class Fatura
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        [Column("Data_Leitura")]
        public string DataLeitura { get; set; }
        [Column("Data_Vencimento")]
        public string DataVencimento { get; set; }
        [Column("Numero_Leitura")]
        public int NumeroLeitura { get; set; }
        [Column("Valor_Conta")]
        public float ValorConta { get; set; }
        [ForeignKey("Id_Instalacao")]
        public Instalacao Instalacao { get; set; }
    }
}
