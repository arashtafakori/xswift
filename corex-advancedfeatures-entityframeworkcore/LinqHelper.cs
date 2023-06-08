using System.Linq.Expressions;

namespace CoreX.AdvancedFeatures.EntityFrameworkCore
{
    public class LinqHelper
    {
        public static Expression<Func<TEntity, bool>> KeyValuesToExpression<TEntity>(params object[] keyValues)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            Expression? expression = null;

            foreach (var property in keyValues.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(keyValues);
                var propertyExpression = Expression.Equal(Expression.Property(parameter, property.Name), Expression.Constant(propertyValue));

                expression = expression == null ? propertyExpression : Expression.And(expression, propertyExpression);
            }

            return Expression.Lambda<Func<TEntity, bool>>(expression!, parameter);
        }

    }
}
