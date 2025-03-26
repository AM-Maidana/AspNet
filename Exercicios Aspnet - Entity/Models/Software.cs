using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicios_ASPNET_Banco.Models
{
    [Table("software")]
    public class Software
    {
        [Column("id_software")]
        public int id {get; set;}
        [Column("produto")]
        public string produto {get; set;}
        [Column("hardDisk")]
        public int hardDisk {get; set;}
        [Column("memoria_Ram")]
        public int memoria_Ram {get; set;}
        [Column("maquina_id")]
        public int maquina_id {get; set;}
        [ForeignKey("maquina_id")]
        [Column("maquina_id")]
        public Maquina maquina { get; set; }
    }
}
/*       [Key]
        public int id { get; set; }
        [Column("nome")]
        public string nome { get; set; } = string.Empty;
        [Column("medicamento_id")]
        public int medicamento_id { get; set; }
        [Column("quantidade")]
        public int quantidade { get; set; }
        [Column("ultima_atualizacao")]
        public DateTime ultima_atualizacao { get; set; }
        [ForeignKey("medicamento_id")]
        [Column("medicamento_id")]
        public Medicamentos medicamento { get; set; }*/