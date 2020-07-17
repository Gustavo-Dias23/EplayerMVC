using System;
using System.Collections.Generic;
using System.IO;
using Aula37EPlayer.Interfaces;

namespace Aula37EPlayer.Models
{
    public class Noticias : EplayersBase, iNoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/noticias.csv";
        /// <summary>
        /// Método construtor
        /// </summary>
        public Noticias(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Método para preparar linha no csv
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        private string PrepararLinha(Noticias news){
            return $"{news.IdNoticia};{news.Titulo};{news.Texto};{news.Imagem}";
        }
        /// <summary>
        /// Método para adicionar notícia
        /// </summary>
        /// <param name="news"></param>
        public void Create(Noticias news)
        {
            string[] linha = { PrepararLinha(news) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Método para ler e passar para o csv
        /// </summary>
        /// <returns></returns>
        public List<Noticias> ReadAll()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas){
                string[] linha = item.Split(";");
                Noticias noticia = new Noticias();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha[2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }
        /// <summary>
        /// Método para alterar algo na notícia
        /// </summary>
        /// <param name="news"></param>
        public void Update(Noticias news)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == news.IdNoticia.ToString());
            linhas.Add(PrepararLinha(news));
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Método para deletar uma notícia pelo seu id
        /// </summary>
        /// <param name="IdNoticia"></param>
        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}