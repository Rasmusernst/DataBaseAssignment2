using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Genre
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movie { get; set; }

        public Genre()
        {
            Movie = new List<Movie>();
        }
    }
}
