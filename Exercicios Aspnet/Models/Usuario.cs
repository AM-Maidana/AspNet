using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicios_ASPNET_Banco.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Column("id")]
        public int id {get; set;}
        [Column("senha")]
        public string senha {get; set;}
        [Column("nome")]
        public string nome {get; set;}
        [Column("ramal")]
        public int ramal {get; set;}
        [Column("especialidade")]
        public string especialidade {get; set;}
    }
}