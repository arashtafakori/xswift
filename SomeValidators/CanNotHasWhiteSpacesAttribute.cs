using Artaco.Infrastructure.CoreX.Properties;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Artaco.Infrastructure.CoreX
{
    public class CanNotHasWhiteSpacesAttribute : ValidationAttribute
    {
        public CanNotHasWhiteSpacesAttribute() : base(string.Format(CultureInfo.CurrentCulture,
                    Resources.CanNotHasWhiteSpaces))
        {

        }

        public override bool IsValid(object value)
        {
            if(value == null)
                throw new ArgumentNullException();
 
            if (new Regex(SomeRegexPatterns.CAN_NOT_HAS_WHITE_SPACES).IsMatch((string)value!))
                return false;
        
            return true;
        }
    }
}
