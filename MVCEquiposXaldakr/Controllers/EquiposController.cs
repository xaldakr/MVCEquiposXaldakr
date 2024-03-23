using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCEquiposXaldakr.Models;

namespace MVCEquiposXaldakr.Controllers
{
    public class EquiposController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;
        public EquiposController(equiposDbContext equiposDbContext) {
            _equiposDbContext = equiposDbContext;
        }
        public IActionResult Index()
        {
            var listamarcas = (from m in _equiposDbContext.marcas
                               select m).ToList();
            ViewData["listaMarcas"] = new SelectList(listamarcas, "id_marcas", "nombre_marca");
            var listaestados = (from e in _equiposDbContext.estados_equipo
                                select e).ToList();
            ViewData["listaEstados"] = new SelectList(listaestados, "id_estados_equipo", "descripcion");
            var listatipos = (from t in _equiposDbContext.tipo_equipo
                              select t).ToList();
            ViewData["listaTipos"] = new SelectList(listatipos, "id_tipo_equipo", "descripcion");

            //Listado de equipos
            var listaequipos = (from e in _equiposDbContext.equipos
                                join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                select new
                                {
                                    nombre = e.nombre,
                                    descripcion = e.descripcion,
                                    marca_id = e.marca_id,
                                    marca_nombre = m.nombre_marca
                                }).ToList();
            ViewData["listaEquipos"] = listaequipos;
            return View();
        }
        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
