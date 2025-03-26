using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicios_ASPNET_Banco.Models
{
    [Table("maquinas")]
    public class Maquina
    {
        [Column("id")]
        public int id {get; set;}
        [Column("tipo")]
        public string tipo {get; set;}
        [Column("velocidade")]
        public int velocidade {get; set;}
        [Column("harddisk")]
        public int harddisk {get; set;}
        [Column("placarede")]
        public int placarede {get; set;}
        [Column("memoriaram")]
        public int memoriaram {get; set;}
        [Column("usuario_id")]
        public int usuario_id {get; set;}
        [ForeignKey("usuario_id")]
        [Column("usuario_id")]
        public Usuario usuario { get; set; }
    }
}
