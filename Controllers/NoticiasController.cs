using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.IO;
using Aula37EPlayer.Models;

namespace Aula37EPlayer.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiaModel = new Noticias();
        /// <summary>
        /// Método construtor de notícias
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(){
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }
        /// <summary>
        /// Método para cadastrar uma Noticia 
        /// </summary>
        /// <param name="form"></param>
        /// <returns>retorno em formulário</returns>
        public IActionResult Cadastrar(IFormCollection form)
        {
           Noticias novaNoticia = new Noticias();

            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo = form["Titulo"];
            novaNoticia.Texto = form["Texto"];

            var file   = form.Files[0];
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using(var stream = new FileStream(path, FileMode.Create) )
                {
                    file.CopyTo(stream);
                }
                novaNoticia.Imagem = file.FileName;
            }
            else
            {
                novaNoticia.Imagem = "padrao.png";
            }

            noticiaModel.Create(novaNoticia);
            ViewBag.Equipes = noticiaModel.ReadAll();
            return LocalRedirect("~/Noticias");
        }
        /// <summary>
        /// Método para excluir uma notícia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Notica/{id}")]
        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);
            return LocalRedirect("~/Noticias");}
    }
}