using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class GenreBLL
    {
        private GenreDAL _genreDAL = new GenreDAL();

        public GenreBLL()
        {
        }

        public void CreateGenre(Genre genre)
        {
            _genreDAL.CreateGenre(genre);
        }

        public List<Genre> GetGenres()
        {
            return _genreDAL.GetGenres();
        }

        public Genre GetGenre(string genreId)
        {
            return _genreDAL.GetGenre(genreId);
        }

        public Genre GetGenreByName(string genreName)
        {
            return _genreDAL.GetGenreByName(genreName);
        }

        public void UpdateGenre(Genre genre)
        {
            _genreDAL.UpdateGenre(genre);
        }

        public void DeleteGenre(string genreId)
        {
            _genreDAL.DeleteGenre(genreId);
        }
    }
}
