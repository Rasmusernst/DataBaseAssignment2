using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDatabase<T>
    {
        void CreateGenre(T genre);
        List<T> GetGenres();
        T GetGenre (string genreId);    
        void UpdateGenre(T genre);
        void DeleteGenre(string genreId);
        T GetGenreByName(string genreName);
    }
}
