namespace Events.Domain.Abstractions
{
    public interface IEntity
    {
        public DateTime CreatedAt { get; set; }
        public EntityStatus Status { get; set; }
    }
    public enum EntityStatus
    {
        Active,
        Deleted,
        Archived
    }
}

