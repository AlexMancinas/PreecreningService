using Atos.Core.Abstractions;

namespace Domain.Common
{
    public class EntityBaseAuditable : IEntityBase<Guid, Guid> 
    {
        public DateTime? ModifyDate { get ; set; }
        public Guid ModifiedBy { get; set; }
        public Guid Id { get; set; }
        public bool State { get; set; }
        public Guid UserCreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
