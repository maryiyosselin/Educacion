using Educacion.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educacion.Web.Controllers
{
    public class HomeController : Controller
    {
        MateriasBL _materiasBL;
        NotasBL _notasBL;

        public HomeController()
        {
            _materiasBL = new MateriasBL();
            _notasBL = new NotasBL();
        }

        public ActionResult Index()
        {
            var materias = _materiasBL.ObtenerMateriasActivos();
            ViewBag.MateriaId = new SelectList(materias, "Id", "Materia");

            return View();
        }

        [HttpPost]
        public ActionResult Index(Materias materia)
        {
            var materias = _materiasBL.ObtenerMateriasActivos();
            ViewBag.MateriaId = new SelectList(materias, "Id", "Materia");

            ViewBag.NotasDetalle = _notasBL.ObtenerNotasPorMateria(materia.Id);

            return View();
        }
    }
}