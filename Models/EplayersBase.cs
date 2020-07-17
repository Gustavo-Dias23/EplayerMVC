using System.Collections.Generic;
using System.IO;

namespace Aula37EPlayer.Models
{
    public class EplayersBase
    {
        /// <summary>
        /// Método para criar pasta e arquiva .csv
        /// </summary>
        /// <param name="_path"></param>
        public void CreateFolderAndFile(string _path){
            string folder = _path.Split("/")[0];
            string file = _path.Split("/")[1];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }
            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }
        }
        /// <summary>
        /// Método para reescrever o arquivo .csv depois de excluir
        /// </summary>
        /// <param name="PATH"></param>
        /// <param name="linhas"></param>
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
        /// <summary>
        /// Método para ler todas as linhas do csv
        /// </summary>
        /// <param name="PATH"></param>
        /// <returns></returns>
        public List<string> ReadAllLinesCSV(string PATH){
            
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
    }
}