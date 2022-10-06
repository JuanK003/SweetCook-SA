using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SweetCook_SA.Models
{
    [Table("DepartamentoSucursal")]
    public class DepartamentoSucursal
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NombreDepartamento { get; set; }

        // Importa llave primaria
        public ICollection<Sucursal> TablaSucursal { get; set; }
    }
}