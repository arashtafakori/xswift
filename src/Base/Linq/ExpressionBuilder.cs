using System.Linq.Expressions;

namespace XSwift.Base
{
    /// <summary>
    /// Represents a builder for creating complex expressions using AND, OR, and NOT logical operations.
    /// </summary>
    /// <typeparam name="T">The type of entity for which the expressions are built.</typeparam>
    public class ExpressionBuilder<T> where T : class
    {
        private Expression<Func<T, bool>> _expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionBuilder{T}"/> class with a default true expression.
        /// </summary>
        public ExpressionBuilder()
        {
            _expression = x => true;
        }

        /// <summary>
        /// Gets the current expression.
        /// </summary>
        /// <returns>The current expression.</returns>
        public Expression<Func<T, bool>> GetExpression()
        {
            return _expression;
        }

        /// <summary>
        /// Combines the current expression with another expression using the OR logical operation.
        /// </summary>
        /// <param name="expression">The expression to be combined using OR.</param>
        public void Or(Expression<Func<T, bool>> expression)
        {
            if (_expression == null)
            {
                _expression = expression;
            }
            else
            {
                var invokedExpr = Expression.Invoke(expression, _expression.Parameters.Cast<Expression>());
                _expression = Expression.Lambda<Func<T, bool>>
                      (Expression.OrElse(_expression.Body, invokedExpr), _expression.Parameters);
            }
        }

        /// <summary>
        /// Combines the current expression with another expression using the AND logical operation.
        /// </summary>
        /// <param name="expression">The expression to be combined using AND.</param>
        public void And(Expression<Func<T, bool>> expression)
        {
            var invokedExpr = Expression.Invoke(expression, _expression.Parameters.Cast<Expression>());
            _expression = Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(_expression.Body, invokedExpr), _expression.Parameters);
        }

        /// <summary>
        /// Negates the specified expression using the NOT logical operation.
        /// </summary>
        /// <param name="expression">The expression to be negated.</param>
        /// <returns>The negated expression.</returns>
        public Expression<Func<T, bool>> Not(Expression<Func<T, bool>> expression)
        {
            var parameter = expression.Parameters[0];
            var body = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        /// <summary>
        /// Combines the current expression with the negation of another expression using the AND logical operation.
        /// </summary>
        /// <param name="expression">The expression to be negated and combined using AND.</param>
        public void AndNot(Expression<Func<T, bool>> expression)
        {
            And(Not(expression));
        }

        /// <summary>
        /// Combines the current expression with the negation of another expression using the OR logical operation.
        /// </summary>
        /// <param name="expression">The expression to be negated and combined using OR.</param>
        public void OrNot(Expression<Func<T, bool>> expression)
        {
            Or(Not(expression));
        }
    }
}

