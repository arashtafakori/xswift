using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using XSwift.Base;

namespace XSwift.Test.Base
{
    [TestClass]
    public class ExpressionBuilderTests
    {
        private class TestModel
        {
            public string Property1 { get; set; }
            public int Property2 { get; set; }
        }

        [TestMethod]
        public void GetExpression_ShouldReturnTrueExpression_WhenInitialized()
        {
            // Arrange
            var builder = new ExpressionBuilder<TestModel>();

            // Act
            var expression = builder.GetExpression();

            // Assert
            expression.Compile().Invoke(new TestModel()).Should().BeTrue();
        }

        [TestMethod]
        public void Or_ShouldCombineExpressionsUsingOr_WhenCalled()
        {
            // Arrange
            var builder = new ExpressionBuilder<TestModel>();
            Expression<Func<TestModel, bool>> expression1 = e => e.Property1 == "Value1";
            Expression<Func<TestModel, bool>> expression2 = e => e.Property2 == 42;

            // Act
            builder.Or(expression1);
            builder.Or(expression2);
            var combinedExpression = builder.GetExpression();

            // Assert
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value1", Property2 = 42 }).Should().BeTrue();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value2", Property2 = 42 }).Should().BeTrue();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value1", Property2 = 43 }).Should().BeTrue();
            //combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value2", Property2 = 43 }).Should().BeFalse();
        }

        [TestMethod]
        public void And_ShouldCombineExpressionsUsingAnd_WhenCalled()
        {
            // Arrange
            var builder = new ExpressionBuilder<TestModel>();
            Expression<Func<TestModel, bool>> expression1 = e => e.Property1 == "Value1";
            Expression<Func<TestModel, bool>> expression2 = e => e.Property2 == 42;

            // Act
            builder.And(expression1);
            builder.And(expression2);
            var combinedExpression = builder.GetExpression();

            // Assert
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value1", Property2 = 42 }).Should().BeTrue();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value2", Property2 = 42 }).Should().BeFalse();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value1", Property2 = 43 }).Should().BeFalse();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value2", Property2 = 43 }).Should().BeFalse();
        }

        [TestMethod]
        public void Not_ShouldNegateExpression_WhenCalled()
        {
            // Arrange
            var builder = new ExpressionBuilder<TestModel>();
            Expression<Func<TestModel, bool>> expression = e => e.Property1 == "Value1";

            // Act
            var negatedExpression = builder.Not(expression);

            // Assert
            negatedExpression.Compile().Invoke(new TestModel { Property1 = "Value1" }).Should().BeFalse();
            negatedExpression.Compile().Invoke(new TestModel { Property1 = "Value2" }).Should().BeTrue();
        }

        [TestMethod]
        public void AndNot_ShouldCombineExpressionWithNegationUsingAnd_WhenCalled()
        {
            // Arrange
            var builder = new ExpressionBuilder<TestModel>();
            Expression<Func<TestModel, bool>> expression = e => e.Property1 == "Value1";

            // Act
            builder.AndNot(expression);
            var combinedExpression = builder.GetExpression();

            // Assert
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value1" }).Should().BeFalse();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value2" }).Should().BeTrue();
        }

        [TestMethod]
        public void OrNot_ShouldCombineExpressionWithNegationUsingOr_WhenCalled()
        {
            // Arrange
            var builder = new ExpressionBuilder<TestModel>();
            Expression<Func<TestModel, bool>> expression = e => e.Property1 == "Value1";

            // Act
            builder.OrNot(expression);
            var combinedExpression = builder.GetExpression();

            // Assert
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value1" }).Should().BeTrue();
            combinedExpression.Compile().Invoke(new TestModel { Property1 = "Value2" }).Should().BeTrue();
        }
    }
}
