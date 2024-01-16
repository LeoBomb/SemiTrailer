namespace SemiTrailer
{
    public class AppsettingOptions
    {
        public ConnectionStrings ConnectionStrings { get; set; }

    }

    public class ConnectionStrings
    {
        public string PostgreSQLConnection { get; set; }
        public string PostgreSQLConnectionRead { get; set; }
        public string TenantPostgreSQL_Server { get; set; }
        public int TenantPostgreSQL_Port { get; set; }
        public string OtherSettings { get; set; }

    }
}
