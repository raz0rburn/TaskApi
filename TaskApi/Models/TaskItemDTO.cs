using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TaskApi.CustomValidation;

namespace TaskApi.Models
{
    public class TaskItemDTO
    {
        public long Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(1024)]
        public string Description { get; set; }
        [ValidDate]
        public string DueDate { get; set; }
        [ValidDate]
        public string CreationDate { get; set; }
        [Required]
        [Range(0, 2, ErrorMessage = "Недопустимый статус")]
        public Status Status { get; set; }
    }
}
