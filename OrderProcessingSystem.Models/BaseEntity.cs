namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public class BaseEntity
    {
         
    }

    public abstract class Entity<T> : BaseEntity
    {
        public virtual T Id { get; set; }
    }
}