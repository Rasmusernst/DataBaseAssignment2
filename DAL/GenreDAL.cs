using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
//using Newtonsoft.Json;
using MongoDB.Bson.Serialization;
using Model;


namespace DAL
{
    public class GenreDAL : IDatabase<Genre>
    {
        private IMongoClient mongoClient;
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        public GenreDAL()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            database = mongoClient.GetDatabase("MovieDb");
            collection = database.GetCollection<BsonDocument>("Genres");
        }
        public void CreateGenre(Genre genre)
        {

            //Placeholder Movies
            var m1 = new Movie() { Name = "Spooky Movie", Description = "Direct trade ugh literally, drinking vinegar VHS occupy asymmetrical artisan cardigan man braid selvage locavore biodiesel snackwave."};
            var m2 = new Movie() { Name = "Adventure Movie", Description = "Yuccie coloring book 90's, adaptogen af selfies poutine dreamcatcher kale chips." };
            var m3 = new Movie() { Name = "Sci-Fi Movie", Description = "Etsy tofu pug, gastropub try-hard coloring book affogato DIY messenger bag hell of tote bag mixtape typewriter letterpress authentic." };
            var m4 = new Movie() { Name = "Action Movie", Description = "Cray bushwick literally letterpress. Jean shorts literally meh, roof party man braid ethical squid activated charcoal." };
            var m5 = new Movie() { Name = "Thriller Movie", Description = "Kinfolk vice XOXO, drinking vinegar hoodie mixtape distillery slow-carb affogato taiyaki celiac before they sold out flannel brooklyn." };

            genre.Movie.Add(m1);
            genre.Movie.Add(m2);
            genre.Movie.Add(m3);
            genre.Movie.Add(m4);
            genre.Movie.Add(m5);

            var itemAsJson = genre.ToJson();
            var itemAsBson = BsonSerializer.Deserialize<BsonDocument>(itemAsJson);
            collection.InsertOne(itemAsBson);
        }

        public List<Genre> GetGenres()
        {
            var items = collection.Find(_ => true).ToList();
            var Genres = new List<Genre>();

            foreach (BsonDocument document in items)
            {
                Genres.Add(BsonSerializer.Deserialize<Genre>(document.AsBsonDocument));
            }
            return Genres;
        }

        public Genre GetGenre(string genreId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(genreId));
            var item = collection.Find(filter).FirstOrDefault();
            return BsonSerializer.Deserialize<Genre>(item.AsBsonDocument);
        }

        public Genre GetGenreByName(string genreName)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Name", genreName);
                var item = collection.Find(filter).FirstOrDefault();
                return BsonSerializer.Deserialize<Genre>(item.AsBsonDocument);
            }
            catch
            {
                return null;
            }


        }
        

        public void UpdateGenre(Genre genre)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", genre.Id);
            var update = Builders<BsonDocument>.Update.Set("Name", genre.Name);
            collection.UpdateOne(filter, update);
        }

        public void DeleteGenre(string genreId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(genreId));
            collection.DeleteOne(filter);
        }
    }
}
