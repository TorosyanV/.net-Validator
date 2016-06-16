namespace Validator
{
   public  abstract class AbstractValidator<T>
   {
       public abstract bool IsValid(T input);
   }
}
