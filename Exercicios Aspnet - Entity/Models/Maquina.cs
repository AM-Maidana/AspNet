using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicios_ASPNET_Banco.Models
{
    [Table("maquina")]
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
        [Column("placa_Rede")]
        public int placa_Rede {get; set;}
        [Column("memoria_Ram")]
        public int memoria_Ram {get; set;}
        [Column("id_usuario")]
        public int id_usuario {get; set;}
        [ForeignKey("id_usuario")]
        [Column("id_usuario")]
        public Usuario usuario { get; set; }
    }
}
