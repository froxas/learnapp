using learnapp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace learnapp.Data
{
    public class ProjectTagConfiguration : IEntityTypeConfiguration<ProjectTag>
    {
        public void Configure(EntityTypeBuilder<ProjectTag> builder)
        {
            //builder.HasKey(t => new { t.ResourceId, t.TagId });

            // Note: 
            // to include Tags must be called 
            // like that .Include(ProjectTags.Tag)
            // .Include(t => t.Tag) will not work!
            builder.HasOne(pt => pt.Resource)
                .WithMany("ProjectTags")
                .HasForeignKey(pt => pt.ResourceId);
            
        }
    }
}