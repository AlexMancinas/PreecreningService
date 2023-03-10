﻿using Atos.Core.Abstractions;

namespace Domain.Common
{
    public interface IEntityBaseAuditable<TKey, TUserKey> 
    {
        public DateTime? ModifyDate { get; set; }
        public TUserKey? ModifiedBy { get; set; } 
    }
}
