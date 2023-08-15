﻿using System.Linq.Expressions;

namespace CoreX.Base
{
    public class ExpressionBuilder<T> where T : class
    {
        private Expression<Func<T, bool>> _expression;
        public ExpressionBuilder()
        {
            _expression = x => true;
        }

        public Expression<Func<T, bool>> GetExpression()
        {
            return _expression;
        }

        public void Or(Expression<Func<T, bool>> expression)
        {
            var invokedExpr = Expression.Invoke(expression, _expression.Parameters.Cast<Expression>());
            _expression = Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(_expression.Body, invokedExpr), _expression.Parameters);
        }

        public void And(Expression<Func<T, bool>> expression)
        {
            var invokedExpr = Expression.Invoke(expression, _expression.Parameters.Cast<Expression>());
            _expression = Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(_expression.Body, invokedExpr), _expression.Parameters);
        }

        public Expression<Func<T, bool>> Invert(Expression<Func<T, bool>> expression)
        {
            var parameter = expression.Parameters[0];
            var body = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}

