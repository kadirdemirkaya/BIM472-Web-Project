using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Mvc.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Required]
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? ChangedAt { get; private set; }
        public bool IsActive { get; private set; } = true;


        public BaseEntity()
        {

        }
        public void SetId(Guid id)
        {
            Id = id;
        }

        public void SetId(string id)
        {
            Id = Guid.Parse(id);
        }

        public void SetChangedDate(DateTime dateTime)
        {
            ChangedAt = dateTime;
        }

        public void AssignGuidToId()
        {
            Id = Guid.NewGuid();
        }

        public void SetActiveState(bool active)
        {
            IsActive = active;
        }
    }
}
