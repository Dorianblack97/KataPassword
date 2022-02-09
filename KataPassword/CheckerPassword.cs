using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword
{
    public class CheckerPassword
    {
        private IValidator validator;
        public CheckerPassword()
        {
            var resultValidation = new ResultValidation { ErrorDescription = new List<string>() };
            validator = new RegularExpressionValidator(resultValidation);
        }
        public ResultValidation Validate(string input) => validator.Validate(input);
    }
}
