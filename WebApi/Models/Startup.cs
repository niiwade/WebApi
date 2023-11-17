using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Startup
    {
        [BsonId]
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }

        public string Rating { get; set; }

        //startup registration number
        public int StartupRegNum { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
