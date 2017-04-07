using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel.DataAnnotations;

namespace vega.Models
{
    public class Make
    {
        public int id {get;set;}
        [Required]
        [StringLength(255)]
        public string name {get;set;}

        public ICollection<Model> Models {get;set;}

        public Make ()
        {
            Models= new Collection<Model>();
        }
        
    }
}