using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aula37EPlayer.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Aula37EPlayer.Controllers
{
    public class EquipeController : Controller
    {
        /// <summary>
        /// Método construtor de equipe
        /// </summary>
        /// <returns></returns>
        Equipe equipeModel = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        /// <summary>
        /// Método para cadastro de equipes
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public IActionResult Cadastrar(IFormCollection form)
        {
            
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaEquipe.Imagem   = file.FileName;
            }
            else
            {
                novaEquipe.Imagem   = "padrao.png";
            }
            // Upload Final
        
            equipeModel.Create(novaEquipe);

            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe");
        }
        /// <summary>
        /// Método para apagar equipe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        public IActionResult Excluir(int id){
            equipeModel.Delete(id);
            return LocalRedirect("~/Equipe");
        }
    }
}
