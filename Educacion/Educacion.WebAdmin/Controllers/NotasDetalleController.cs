using Educacion.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educacion.WebAdmin.Controllers
{
    public class NotasDetalleController : Controller
    {
        NotasBL _NotasBL;
        MateriasBL _MateriasBL;


        public NotasDetalleController()
        {
            _NotasBL = new NotasBL();
            _MateriasBL = new MateriasBL();
        }


        // GET: NotasDetalle
        public ActionResult Crear(int id)
        {
            var nuevaNotasDetalle = new NotasDetalle();
            nuevaNotasDetalle.NotaId  = id;

            var Materias = _MateriasBL.ObtenerMaterias();
            ViewBag.MateriasId = new SelectList(Materias , "Id", "Descripcion");

            return View(nuevaNotasDetalle);
        }
    }
}