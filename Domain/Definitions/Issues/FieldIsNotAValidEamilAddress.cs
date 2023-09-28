using XSwift.Properties;
using System.Globalization;

namespace XSwift.Domain
{
    public class FieldIsNotAValidEamilAddress : ValidationIssue
    {
        public FieldIsNotAValidEamilAddress(
            string fieldName = "", string description = "") :
            base (outerDescription: description,
                innerDescription: string.Format(CultureInfo.CurrentCulture,
                Resource.Validation_Issue_FieldIsNotAValidEmailAddress, fieldName))
        {
        }
    }
}
