using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace liquipages.models
{
    public class Category
    {
        [Key] public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30, ErrorMessage = " Max Length allowed is 30 Charectors")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 - 100")]
        public int DIsplayOrder { get; set; }
    }
}