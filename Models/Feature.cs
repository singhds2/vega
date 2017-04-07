using System.ComponentModel.DataAnnotations;

namespace vega.Models
{
    public class Feature
    {
        [Required]
        [Key]
        public int feature_id {get;set;}

        [Required]
        [StringLength(255)]
        public string feature_name {get;set;}
    }
}