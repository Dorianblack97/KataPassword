using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KataPassword
{
    public class RegularExpressionValidator : AbstractValidator
    {
        public RegularExpressionValidator(ResultValidation resultValidation) : base(resultValidation)
        {
        }

        public override ResultValidation Validate(string input)
        {
            string strRegex = @"^.*(?=.{8,})(?=[0-9].*[0-9])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$";
            bool result = !Regex.IsMatch(input, strRegex);
            if (!Regex.IsMatch(input, strRegex))
            {
                if (!Regex.IsMatch(input, @"^.*(?=.{8,}).*$")) _resultValidation.ErrorDescription.Add("Password must be at least 8 characters");

                if (!Regex.IsMatch(input, @"^.*(?=.*[0-9].*[0-9]).*$")) _resultValidation.ErrorDescription.Add("The password must contain at least 2 number");

                if (!Regex.IsMatch(input, @"^.*(?=.*[A-Z]).*$")) _resultValidation.ErrorDescription.Add("The password must contain at least one capital letter");

                if (!Regex.IsMatch(input, @"^.*(?=.*[!*@#$%^&+=]).*$")) _resultValidation.ErrorDescription.Add("The password must contain at least one special character");

            }
            return _resultValidation;
        }
    }
}
