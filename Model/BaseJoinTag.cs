using System;
using System.ComponentModel.DataAnnotations;
using learnapp.Model;
using learnapp.Shared;

namespace learnapp.Model
{
    public abstract class BaseJoinTag<T> : BaseEntity, IJoinTag<T> 
        where T : BaseEntity
    { 
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
        public Guid ResourceId { get; set; }
        public T Resource { get; set; }
    }
}

