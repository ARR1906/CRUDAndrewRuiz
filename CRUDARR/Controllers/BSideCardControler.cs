//Programa controlador de vistas para CRUD

using CRUDARR.Datos;
using CRUDARR.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDARR.Controllers
{
    public class BSideCardControler : Controller //Se crea la clase controlador
    {
        private readonly ApplicationDbContext _context;   //Creacion de objeto "_context" para la conexion a la BD

        public BSideCardControler(ApplicationDbContext context) //Constructor
        {
            _context = context;
        }


        public IActionResult Index()     //Funcion para pagina principal CRUD
        {
            IEnumerable<BSideCard> listcards = _context.BSideCard;    //Lista los elementos de la Tabla en la BD 
            return View(listcards); //Obtiene la vista dando como parametro la tabla en la BD
        }

        //Metodos Get
        public IActionResult Create() // Funcion que regresa vista  para crear un elemento  en la tabla
        {
            return View();
        }

        public IActionResult Edit(int? id) // Funcion que regresa vista  para Editar un elemento  en la tabla
        {
            if (id == null || id == 0) //Verifica que no exista un id 
            {
                return NotFound(); 
            }

            var tarjeta = _context.BSideCard.Find(id); // Si encuentra el Id regresa la vista tarjeta

            if (tarjeta == null)
            {
                return NotFound();
            }
            return View(tarjeta);
        }

        public IActionResult Delete(int? id) // Funcion que regresa vista  para borrar un elemento  en la tabla
        {
            if (id == null || id == 0) //Verifica que no exista un id 
            {
                return NotFound();
            }

            var tarjeta = _context.BSideCard.Find(id); // Si encuentra el Id regresa la vista tarjeta

            if (tarjeta == null)
            {
                return NotFound();
            }
            return View(tarjeta);
        }

        //Metodos Post


        [HttpPost] //Identifica la funcion con post
        public IActionResult Create(BSideCard bSideCard) //Funcion para verificar datos y agregar a la lista 
        {
            if (ModelState.IsValid)  // Verifica datos del lado del servidor
            {
                _context.BSideCard.Add(bSideCard);
                _context.SaveChanges();

                TempData["mensaje"] = "Se ha creado la tarjeta correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

      


        [HttpPost]
        public IActionResult Edit(BSideCard bSideCard) //Funcion para verificar datos y Editar a la lista 
        {
            if (ModelState.IsValid)       // Verifica datos del lado del servidor
            {
                _context.BSideCard.Update(bSideCard);
                _context.SaveChanges();

                TempData["mensaje"] = "Se ha actualizado la tarjeta correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }


       


        [HttpPost]
        public IActionResult DeleteTarjeta(int? id) //Funcion para verificar datos y eliminar datos a la lista 
        {
            var bSideCard = _context.BSideCard.Find(id);

            if (bSideCard == null)   
            {
                return NotFound();
            }

            
            _context.BSideCard.Remove(bSideCard);
            _context.SaveChanges();

            TempData["mensaje"] = "Se ha eliminado la tarjeta correctamente";
            return RedirectToAction("Index");
        }
    }
}
