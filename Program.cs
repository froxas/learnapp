using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using learnapp.Data;
using learnapp.Helpers;
using learnapp.Model;
using learnapp.Services;
using Microsoft.EntityFrameworkCore;


namespace learnapp
{
    class Program
    {
        static void Main(string[] args)
        {             
           using (var context = new ApplicationDbContext())
            {
                var filterText = "Slengiai";
                //var expression = FilterExpressionBuilder.FilterKey<Employee>(filterText);

                 var expression = CreateExpression(typeof(Employee), "Address");
          
            
            };    
        }   

        public static LambdaExpression CreateExpression(Type type, string propertyName) {
            var param = Expression.Parameter(type, "x");
            Expression body = param;
            foreach (var member in propertyName.Split('.')) {
                body = Expression.PropertyOrField(body, member);
            }
            return Expression.Lambda(body, param);
        }     

        #region DoFilter
        public void DoFilter() 
        {
            using (var context = new ApplicationDbContext())
            {
                var filterText = "Azure";
                var expression = FilterExpressionBuilder.FilterKey<Project>(filterText);

                var employees = context.Projects.Where(expression).ToList();                               
            };    
        }

        #endregion
            
        #region DoTags
        public void DoTags() {
            
            using (var context = new ApplicationDbContext())
            {  
                // update
                var project = context.Projects
                    .Include("ProjectTags.Tag")
                    .FirstOrDefault(p => p.ProjectId.Equals("001"));

                var tags = new List<Tag>() {
                    context.Tags.FirstOrDefault(t => t.Title.Equals("Design")),
                    new Tag {Title = "Java"},
                    new Tag {Title = "C#"}
                };
                
                var id = project.Id;
                // get updated project 
                var updatedProject = new ProjectDto {
                    Id = project.Id,
                    ProjectId = project.ProjectId,
                    Title = project.Title,
                    Tags = tags
                };
                // traukiam lauk projekta
                var oldProject = context.Projects.FirstOrDefault(p => p.Id == id);

                // map
                oldProject.Id = updatedProject.Id;
                oldProject.ProjectId = updatedProject.ProjectId;
                oldProject.Title = updatedProject.Title;

                ITagService<ITaggable> tagService = new TagService<ITaggable>();
                
                // modify
                tagService.MapTags(oldProject, updatedProject);
                

                // save
                context.SaveChanges();               
                
                     
            }    

        }
        #endregion
      
   }    
}
