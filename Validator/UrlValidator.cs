using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
  public  class UrlValidator:AbstractValidator<String>
    {
        public override bool IsValid(string input)
      {

            List<string> valideSchemes=new List<string>()
            {
                Uri.UriSchemeHttp,
                Uri.UriSchemeHttps,
                Uri.UriSchemeFtp

            };
          Uri uriResult;
          return Uri.TryCreate(input, UriKind.Absolute, out uriResult) && valideSchemes.Contains(uriResult.Scheme);
   



            //  return Uri.IsWellFormedUriString(input, UriKind.RelativeOrAbsolute);
            // Uri uri= new Uri(input);
            //return uri.IsWellFormedOriginalString();
      }
    }
}
