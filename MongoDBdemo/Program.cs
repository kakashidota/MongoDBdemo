using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDBdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ConnectionStrings behövs bara för "clouddevelopment"
            //var connectionstring = "mongodb://localhost:27017";


            //Koppling till databas
            var client = new MongoClient();
            var database =client.GetDatabase("Employees"); 
            var collection = database.GetCollection<UserModel>("Persons");

            var user = new UserModel();
            user.FirstName = "Test";
            collection.InsertOne(user);

            //CRUD kommer här

            ////[C]RUD
            //var user = new UserModel
            //{
            //    FirstName = "Robin",
            //    LastName = "Kamo",
            //    Adress = new AdressModel
            //    {
            //        Street = "Salviagatan 38",
            //        City = "Angered"
            //    }
            //};

            //collection.InsertOne(user);

            //C[R]UD

            //var users = collection.Find(_ => true).ToList();
            //foreach (var newUser in users)
            //{
            //    Console.WriteLine($"{newUser.FirstName} {newUser.LastName} {newUser.Adress.City}");
            //}



            ////CR[U]D
            //var filter = Builders<UserModel>.Filter.Eq("FirstName", "Robin");
            //var update = Builders<UserModel>.Update.Set("LastName", "Brage");
            //collection.UpdateOne(filter, update);

            //CRU[D]
            //var deleteFilter = Builders<UserModel>.Filter.Eq("FirstName", "Oliver");
            //collection.DeleteOne(deleteFilter);

        }
    }




    public class UserModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public AdressModel Adress { get; set; }

    }

    public class AdressModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

    }
}