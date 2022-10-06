using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    [Table("Recibe")]
    public class Recibe
    {
        [Required]
        public int Id { get; set; } 
        public DateTime Fecha { get; set; }

        // Recibe llave primaria
        public Envia TablaEnvia { get; set; }
        public int EnviaId { get; set; }
    }
}