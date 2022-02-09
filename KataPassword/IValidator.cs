using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPassword
{
    public interface IValidator
    {
        IValidator SetNext(IValidator validator);
        ResultValidation Validate(string input);
    }
}
