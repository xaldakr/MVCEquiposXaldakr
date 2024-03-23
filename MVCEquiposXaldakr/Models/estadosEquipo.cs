using System.ComponentModel.DataAnnotations;

namespace MVCEquiposXaldakr.Models
{
    public class estadosEquipo
    {
        [Key]
        public int id_estados_equipo { get; set; }
        [StringLength(50)]
        public string? descripcion { get; set; }
        [StringLength(1)]
        public string? estado { get; set; }
    }
}

