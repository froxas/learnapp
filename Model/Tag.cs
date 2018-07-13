using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using learnapp.Shared;

namespace learnapp.Model
{
    public class Tag : BaseEntity
    {    
        public string Title { get; set; }  

       
    }
}