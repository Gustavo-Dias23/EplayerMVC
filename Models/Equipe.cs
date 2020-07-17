using System;
using System.Collections.Generic;
using System.IO;
using Aula37EPlayer.Interfaces;

namespace Aula37EPlayer.Models
{
    public class Equipe : EplayersBase , iEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/equipe.csv";

        /// <summary>
        /// Método Construtor
        /// </summary>
        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Método para criar uma nova equipe
        /// </summary>
        /// <param name="e"></param>
        public void Create(Equipe e)
        {
            string[] linha = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Método para preparar linha no arquivo .csv
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        /// <summary>
        /// Método para excluir equipe do arquivo csv
        /// </summary>
        /// <param name="IdEquipe"></param>
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <returns>Lista de equipes</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
        /// <summary>
        /// Altera uma equipe
        /// </summary>
        /// <param name="e"></param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
        }
    }
}