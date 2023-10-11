using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;
namespace TaskApi.CustomValidation
{
    public class ValidDateAttribute: ValidationAttribute
    {
        public ValidDateAttribute()
        {
            
        }

        public override bool IsValid(object value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);

                if (convertedDate.Date >= DateTime.Now.Date)
                {

                    return true;
                }
                else
                {
                    ErrorMessage = "{0} Date should not be less than current date";
                    return false;
                }      
            }
            catch (FormatException)
            {
                ErrorMessage = "'{0}' is not in the proper format." + value;
                return false;
            }
            catch (InvalidCastException)
            {
                ErrorMessage = "Conversion of the {0} '{1}' is not supported" + value.GetType().Name + value;
                return false;
            } 
        }
    }
}
