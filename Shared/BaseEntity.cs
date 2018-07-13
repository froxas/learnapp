using System;
using System.ComponentModel.DataAnnotations;
using learnapp.Shared;

namespace learnapp.Shared
{   
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}