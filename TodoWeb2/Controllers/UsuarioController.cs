using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoWeb2.Models;

namespace TodoWeb2.Controllers
{
    public class UsuarioController : Controller
    {
        static List<Usuario> lista = new List<Usuario>();

        // GET: Usuario
        public ActionResult Index()
        {
            //lista.Add(new Usuario {UsuarioId = 1, Nome = "Fulano" });
            //lista.Add(new Usuario { UsuarioId = 2, Nome = "Ciclano" });

            //ViewBag.Usuarios = lista;

            return View(lista);
        }

        //GET: /usuario/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            int id = int.Parse(form["UsuarioId"]);
            string Nome = form["Nome"];
            string Email = form["Email"];
            string Senha = form["Senha"];

            lista.Add(new Usuario { UsuarioId = id, Nome = Nome, Email = Email, Senha = Senha });

            //return View();
            return RedirectToAction("Index");
        }
    }
}