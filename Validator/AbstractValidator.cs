using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
   public  abstract class AbstractValidator<T>
   {
       public abstract bool IsValid(T input);
   }
}
