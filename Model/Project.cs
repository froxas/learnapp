using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using learnapp.Shared;

namespace learnapp.Model
{
    public class Project : BaseEntity, ITaggable
    {
        public Project()
            => Tags = new JoinCollectionFacade<Tag, ProjectTag>(
                ProjectTags,
                pt => pt.Tag,
                t => new ProjectTag { Resource = this, Tag = t});
       
        public string ProjectId { get; set; }
        public string Title { get; set; }   

        private ICollection<ProjectTag> ProjectTags { get; } 
            = new List<ProjectTag>();

        [NotMapped]
        public ICollection<Tag> Tags { get; private set; }       
    }
}

