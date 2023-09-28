using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskApi.CustomValidation
{
    public class LessDateAttribute: ValidationAttribute
    {
        public LessDateAttribute() : base("{0} Date should not be less than current date")
        {
            
        }

        public override bool IsValid(object value)
        {
            //long n = long.Parse(date.ToString("dd-MM-yyyy HH:mm:ss zzz"));
            var propValue = Convert.ToDateTime(value);


            if (DateTime.Now > propValue)
                return true;
            else
                return false;
        }
    }
}
