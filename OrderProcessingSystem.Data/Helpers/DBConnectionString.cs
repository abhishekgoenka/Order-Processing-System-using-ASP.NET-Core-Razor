namespace OrderProcessingSystem.Data.Helpers
{
    /// <summary>
    ///     Stores database connection string
    /// </summary>
    public class DBConnectionString
    {
        public DBConnectionString(string dbConnectionString)
        {
            ConnectionString = dbConnectionString;
        }

        public string ConnectionString { get; }
    }
}