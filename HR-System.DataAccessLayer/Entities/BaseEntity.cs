namespace HR_System.Core.Entities
{
    public abstract class BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
    }
}
