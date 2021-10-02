using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment5.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}