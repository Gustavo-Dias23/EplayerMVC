using System.IO;

namespace Aula37EPlayer.Models
{
    public class EplayersBase
    {
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
    }
}