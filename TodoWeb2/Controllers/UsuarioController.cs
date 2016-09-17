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
        //static List<Usuario> lista = new List<Usuario>();

        // GET: Usuario
        public ActionResult Index()
        {
            //lista.Add(new Usuario {UsuarioId = 1, Nome = "Fulano" });
            //lista.Add(new Usuario { UsuarioId = 2, Nome = "Ciclano" });

            //ViewBag.Usuarios = lista;

            using (TodoContext ctx = new TodoContext())
            {
           
           List<Usuario> usuarios = ctx.Usuarios.ToList();
            return View(usuarios);
        }//dispose
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
            //int id = int.Parse(form["UsuarioId"]);
            string Nome = form["Nome"];
            string Email = form["Email"];
            string Senha = form["Senha"];

            Usuario u = new Usuario
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha
            };

            using (TodoContext ctx = new TodoContext())
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
            }
             

            //return View();
            return RedirectToAction("Index");
        }
        //GET: /usuario/update/6   <-----exemplo
        public ActionResult Update(int id)
        {
            using (TodoContext ctx = new TodoContext())
            {
             
                Usuario u = ctx.Usuarios.Find(id); //so o id
               //Usuario u = ctx.Usuarios.SingleOrDefault(e => e.UsuarioId == id); //clausula where
                return View(u);
            }

            
        }
        [HttpPost]
        public ActionResult update(int id, FormCollection form)//aplicando as alteraçoes
        {
            using (TodoContext ctx = new TodoContext())
            {
                Usuario u = ctx.Usuarios.Find(id);
                u.Nome = form["Nome"];
                u.Email = form["Email"];

                ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (TodoContext ctx = new TodoContext())
            {
                Usuario u = ctx.Usuarios.Find(id);

                ctx.Usuarios.Remove(u);
                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["Email"];
            string senha = form["Senha"];

            using (TodoContext ctx = new TodoContext())
            {
                Usuario user = ctx.Usuarios.SingleOrDefault(u => u.Email == email && u.Senha == senha);

                if (user != null)
                {
                    Session["usuario"] = user;
                    Session.Timeout = 1440;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Erro = "Usuario ou senha incorretos";
            return View();
        }
    }
}