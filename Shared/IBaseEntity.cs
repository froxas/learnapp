using System;

namespace learnapp.Shared
{
    /// <summary>
    /// Base interface to store Id key
    /// </summary>
    public interface IBaseEntity
    {
        Guid Id { get; set; }         
    }
}