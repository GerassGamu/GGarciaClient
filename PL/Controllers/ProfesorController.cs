using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult GetAll()
        {
            //Creación objeto clase 
            ML.Profesor profesor = new ML.Profesor();
            //Result para cargar método
            ML.Result result = BL.Profesor.GetAllClient();
            //Si el result es correcto nos muestra la vista del GetAll
            if (result.Correct)
            {
                ///Llena el GetAll
                profesor.Profesores = result.Objects.ToList();
                ///Retorna Vista
                return View(profesor);
            }
            else
            {
                //En caso contrario nos manda mensaje en el modal que generamos
                ViewBag.Message("Ocurrió al traer registros de Profesores " + result.ErrorMessage);

                return PartialView("Modal");
            }

        }
        [HttpGet]
        public ActionResult Form(int? IdProfesor)
        {
            //Instancia de clase Profesor
            ML.Profesor profesor = new ML.Profesor();

            if (IdProfesor == null)//ADD
            {
                return View(profesor);
            }
            else //Update 
            {
                ML.Result result = BL.Profesor.GetByIdClient(IdProfesor.Value);

                if (result.Correct)
                {
                    // ML.Aseguradora aseguradora = new ML.Aseguradora();
                    profesor = ((ML.Profesor)result.Object);


                    return View(profesor);

                }
                else
                {
                    ViewBag.Message = "No se pudo realizar la consulta" + result.ErrorMessage;
                    return PartialView("Modal");
                }

            }
        }
        [HttpPost]
        public ActionResult Form(ML.Profesor profesor)
        {
            if (profesor.IdProfesor == 0)
            {
                ML.Result result = BL.Profesor.AddClient(profesor);
                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente un Profesor";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al insertar el Profesor" + result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ML.Result result = BL.Profesor.UpdateClient(profesor);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizó correctamente un Profesor";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Messge = "No se actualizó correctamente un Profesor";
                    return PartialView("Modal");
                }
            }

        }

        [HttpGet]
        public ActionResult Delete(int IdProfesor)
        {
            ML.Profesor profesor = new ML.Profesor();
            profesor.IdProfesor = IdProfesor;
            var result = BL.Profesor.DeleteClient(profesor);

            if (result.Correct)
            {

                ViewBag.Message = "El profesor se ha eliminado correctamente";


            }
            else
            {
                ViewBag.Message = "Error al eliminar  Profesor";



            }
            return PartialView("Modal");
        }

    }
}