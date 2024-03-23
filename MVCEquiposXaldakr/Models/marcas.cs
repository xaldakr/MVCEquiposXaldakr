using System.ComponentModel.DataAnnotations;

namespace MVCEquiposXaldakr.Models
{
    public class marcas
    {
        [Key]
        [Display(Name ="ID")]
        public int id_marcas { get; set; }
        [Display(Name = "Nombre de la marca")]
        [Required(ErrorMessage ="Ingrese el nombre de la marca")]
        [StringLength(50)]
        public string? nombre_marca { get; set; }
        [Display(Name = "Estado")]
        [StringLength(1)]
        public string? estados { get; set; }
    }
}
