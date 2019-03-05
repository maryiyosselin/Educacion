﻿using Educacion.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educacion.WebAdmin.Controllers
{
    public class MateriasController : Controller
    {
        MateriasBL _materiasBL;
        CursosBL _cursosBL;


        public MateriasController()
        {
            _materiasBL = new MateriasBL();
            _cursosBL = new CursosBL();


        }

        // GET: Materias
        public ActionResult Index()
        {
            var listadeMaterias = _materiasBL.ObtenerMaterias();


            return View(listadeMaterias);
        }

        public ActionResult Crear()
        {
            var nuevoMaterias = new Materias();
           
            var cursos = _cursosBL.ObtenerCursos();

            ViewBag.CursoId =
                new SelectList(cursos, "Id", "Curso");

            return View(nuevoMaterias);

        }

        [HttpPost]
        public ActionResult Crear(Materias materias)
        {
            _materiasBL.GuardarMaterias(materias);


            return RedirectToAction("Index");

        }

        public ActionResult Editar(int id)
        {
            var materias = _materiasBL.ObtenerMaterias(id);
            var cursos = _cursosBL.ObtenerCursos();

            ViewBag.CursoId =
                new SelectList(cursos, "Id", "Curso", materias.CursoId);

            return View(materias);

        }

        [HttpPost]
        public ActionResult Editar(Materias materias)
        {
            _materiasBL.GuardarMaterias(materias);
            return RedirectToAction("Index");

        }

        public ActionResult Detalle(int id)
        {
            var materias = _materiasBL.ObtenerMaterias(id);
            var cursos = _cursosBL.ObtenerCursos();

            ViewBag.CursoId =
                new SelectList(cursos, "Id", "Curso", materias.CursoId);
            return View(materias);
        }

        public ActionResult Eliminar(int id)
        {
            var materias = _materiasBL.ObtenerMaterias(id);
            var cursos = _cursosBL.ObtenerCursos();

            ViewBag.CursoId =
                new SelectList(cursos, "Id", "Curso", materias.CursoId);
            return View(materias);
        }
        [HttpPost]
        public ActionResult Eliminar(Materias materias)
        {
            _materiasBL.EliminarMaterias(materias.Id);
            return RedirectToAction("Index");
        }
    }
}