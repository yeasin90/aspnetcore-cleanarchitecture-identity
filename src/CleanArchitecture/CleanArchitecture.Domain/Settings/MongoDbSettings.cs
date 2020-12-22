namespace CleanArchitecture.Domain.Settings
{
    public class MongoDbSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Alias { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }

        // MongoDb with MONGO_INITDB_ROOT_USERNAME and MONGO_INITDB_ROOT_PASSWORD requires a formatted connection string
        // format : mongodb://username:password@host:port
        public string AuhthorizedConnectionString => $"{Alias}://{Username}:{Password}@{Host}:{Port}";
    }
}
