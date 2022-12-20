using System.Collections;

namespace CoreX.Structure
{
    public class ErrorFactory
    {
        public static PrimitiveError CreateBusinessLikeError(string code,
        string description,
        IDictionary? data = null)
        {
            return new PrimitiveError(
                code,
                Constants.BUSINESSLIKE_ERROR + description,
                ErrorType.BusinessLike,
                data);
        }
        public static PrimitiveError CreateValidationError(string code,
                string description,
                IDictionary? data = null)
        {
            return new PrimitiveError(
                code,
                Constants.VALIDATION_ERROR + description,
                ErrorType.Validation,
                data);
        }
        public static PrimitiveError CreateTechnicalError(string code,
            string description,
            IDictionary? data = null)
        {
            return new PrimitiveError(
                code,
                description,
                ErrorType.Technical,
                data);
        }
    }
}
