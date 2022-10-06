using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    [Table("DepartamentoRecibe")]
    public class DepartamentoRecibe
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreDepartamentoRecibe { get; set; }

        // Importa llave primaria
        public ICollection<Envia> TablaEnvia { get; set; }
    }
}