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
        //GET: /usuario/update/6   <-----exemplo
        public ActionResult Update(int id)
        {
            foreach (var item in lista)
            {
                if (item.UsuarioId == id)
                {
                    return View(item);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult update(FormCollection form)//aplicando as alteraçoes
        {
            int id = int.Parse(form["UsuarioId"]);
            foreach (var item in lista)
            {
                if (item.UsuarioId == id)
                {
                    item.Nome = form["Nome"];
                    item.Email = form["Email"];
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            foreach (var item in lista)
            {
                if (item.UsuarioId == id)
                {
                    lista.Remove(item);
                    break;
                }

            }

            return RedirectToAction("Index");
        }
    }
}