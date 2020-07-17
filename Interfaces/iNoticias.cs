using System.Collections.Generic;
using Aula37EPlayer.Models;

namespace Aula37EPlayer.Interfaces
{
    public interface iNoticias
    {
         void Create(Noticias news);
         List<Noticias> ReadAll();
         void Update(Noticias news);    
         void Delete(int IdNoticia);
    }
}