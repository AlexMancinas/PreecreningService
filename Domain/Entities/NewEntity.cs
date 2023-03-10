using Atos.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NewEntity : IEntityBase<Guid, Guid>
    {
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid UserCreatorId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
