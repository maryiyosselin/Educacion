using Educacion.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educacion.WebAdmin.Controllers
{
    public class NotasController : Controller
    {

        NotasBL _NotasBL;
        EstudiantesBL _EstudiantesBL;
        public NotasController()
        {

            _NotasBL = new NotasBL();
            _EstudiantesBL = new EstudiantesBL();

        }

        // GET: Notas
        public ActionResult Index()
        {


            var listadeNotas = _NotasBL.ObtenerNotas();

            return View(listadeNotas);
        }

        public ActionResult Crear()
        {

            var nuevaNota = new Notas();
            var Estudiantes = _EstudiantesBL.ObtenerEstudiantes();
            ViewBag.EstudianteID = new SelectList(Estudiantes, "Id", "Nombre");
            return View(nuevaNota);

        }


        [HttpPost]
        public ActionResult Crear(Notas Notas)
        {
            if (ModelState.IsValid)
            {
                if (Notas.EstudianteId == 0)
                {
                    ModelState.AddModelError("EstudianteId", "Seleccione un Estudiante");
                    return View(Notas);

                }


                _NotasBL.GuardarNotas(Notas);

                return RedirectToAction("Index");

            }
            var Estudiantes = _EstudiantesBL.ObtenerEstudiantes();
            ViewBag.EstudianteID = new SelectList(Estudiantes, "Id", "Nombre");
            return View(Notas);

        }

        public ActionResult Editar(int id)
        {
            var Notas = _NotasBL.ObtenerNotas(id);
            var Estudiantes = _EstudiantesBL.ObtenerEstudiantes();
            ViewBag.EstudianteID = new SelectList(Estudiantes, "Id", "Nombre", Notas.EstudianteId);

            return View(Notas);
        }

        [HttpPost]
        public ActionResult Editar(Notas  Notas)
        {
            if (ModelState.IsValid)
            {
                if (Notas .EstudianteId == 0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(Notas );
                }

                _NotasBL.GuardarNotas(Notas );

                return RedirectToAction("Index");
            }

            var Estudiantes = _EstudiantesBL.ObtenerEstudiantes();

            ViewBag.EstudianteId = new SelectList(Estudiantes , "Id", "Nombre", Notas .EstudianteId );

            return View(Notas );
        }



        public ActionResult Detalle(int id)
        {
            var Notas = _NotasBL.ObtenerNotas(id);

            return View(Notas );
        }


    }
    }
