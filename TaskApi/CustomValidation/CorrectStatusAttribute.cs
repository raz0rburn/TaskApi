using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskApi.CustomValidation
{
    public class CorrectStatusAttribute : ValidationAttribute
    {
        private List<String> status;
        public CorrectStatusAttribute() : base("{0} Status value incorrect")
        {
            status = new List<String>() { "Created", "In process", "Completed" };

        }

        public override bool IsValid(object value)
        {
            if (status.Contains(value))
                return true;
            else
                return false;
        }
    }
}
