using System.Collections.Generic;

namespace learnapp.Model
{
    /// <summary>
    /// ITaggable interface must be implemented in order 
    /// to map tags from Dto to entity tag's collection
    /// </summary>
    public interface ITaggable
    {
         ICollection<Tag> Tags { get; }   
    }
}