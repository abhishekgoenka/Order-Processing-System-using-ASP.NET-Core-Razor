namespace OrderProcessingSystem.Models
{
    /// <summary>
    ///     Client Type view model
    /// </summary>
    public class ClientType : Entity<int>
    {
        /// <summary>
        ///     Type of client
        /// </summary>
        public string Text { get; set; }
    }
}