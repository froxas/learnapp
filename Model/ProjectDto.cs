using System;
using System.Collections.Generic;

namespace learnapp.Model
{
    public class ProjectDto : ITaggable
    {
        public Guid Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}