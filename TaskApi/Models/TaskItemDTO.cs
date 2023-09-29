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
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidDate]
        public string DueDate { get; set; }
        [ValidDate]
        public string CreationDate { get; set; }

        public Status Status { get; set; }

    }
}
