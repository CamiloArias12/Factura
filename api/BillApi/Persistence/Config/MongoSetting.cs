namespace BillApi.Persisntence.Config
{
    public class MongoSettings
    {
        public required string ConnectionString { get; set; }
        public required string Database { get; set; }
    }

}