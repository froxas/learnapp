using System;
using learnapp.Model;
using learnapp.Shared;

namespace learnapp.Model
{    
    public interface IJoinTag<T> where T : BaseEntity
    {
        /// <summary>
        /// Base interface for join entities
        /// implementing many-to-many relation
        /// </summary>
        /// <value></value>
        Guid TagId { get; set; }
        Tag Tag { get; set; }

        Guid ResourceId { get; set; }
        T Resource { get; set; }        
    }
  
}