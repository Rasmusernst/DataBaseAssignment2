using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Movie()
        {
            Id = ObjectId.GenerateNewId();
        }

    }
}
