using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskApi.CustomValidation
{
    public class CorrectStatusAttribute : ValidationAttribute
    {
        private List<String> Status;
        public CorrectStatusAttribute() : base("{0} Status value incorrect")
        {
            Status = new List<String>() { "Created", "In process", "Completed" };

        }

        public override bool IsValid(object value)
        {
            if (Status.Contains(value))
                return true;
            else
                return false;
        }
    }
}
