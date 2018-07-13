using System.Collections.Generic;
using learnapp.Model;

namespace learnapp.Services
{
    public interface ITagService<T>  where T : ITaggable
    {
        /// <summary>
        /// Maps Tags property from Dto to Entity class
        /// classes must implement Itaggable
        /// </summary>
        /// <param name="OldEntity">Entity class</param>
        /// <param name="UpdatedEntity">Dto class</param>
        void MapTags(T OldEntity, T UpdatedEntity);
    }
}