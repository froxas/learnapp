using System;
using System.Collections.Generic;
using System.Linq;
using learnapp.Data;
using learnapp.Model;

namespace learnapp.Services
{
    public class TagService<T> : ITagService<T> where T : ITaggable
    {        
        public void MapTags(T OldEntity, T UpdatedEntity)
        {    
            var tagsToRemove = OldEntity.Tags.Except(UpdatedEntity.Tags);
            RemoveTags(tagsToRemove);

            OldEntity.Tags.Clear();

            foreach (var tag in UpdatedEntity.Tags)
                OldEntity.Tags.Add(tag);
        }

        private void RemoveTags(IEnumerable<Tag> tagsToRemove) 
        {
            // TODO: implement unused tags removal from DB
            using (var context = new ApplicationDbContext())
            {                                  
                context.SaveChanges();                                   
            }            
        }
    }
}