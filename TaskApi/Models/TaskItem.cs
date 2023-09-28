using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TaskApi.CustomValidation;
namespace TaskApi.Models
{
    public partial class TaskItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



        [LessDate]
        public string DueDate { get; set; }
        [LessDate]
        public string CreationDate { get; set; }
        [LessDate]
        public string CompletionDate { get; set; }

        [CorrectStatus]
        public string Status { get; set; }
    }
}


