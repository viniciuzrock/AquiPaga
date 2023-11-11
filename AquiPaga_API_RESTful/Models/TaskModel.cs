using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquiPaga_API_RESTful.Models
{
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="VARCHAR")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
