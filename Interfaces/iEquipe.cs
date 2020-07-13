using System.Collections.Generic;
using Aula37EPlayer.Models;
namespace Aula37EPlayer.Interfaces
{
    public interface iEquipe
    {
         void Create(Equipe e);
         List<Equipe> ReadAll();
         void Update(Equipe e);
         void Delete(int id);
    }
}