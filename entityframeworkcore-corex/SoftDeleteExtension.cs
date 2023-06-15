using CoreX.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace EntityFrameworkCore.CoreX
{
    public static class SoftDeleteExtension
    {
        public static void AddSoftDeleteCapabilityForQuery(
            this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var methodToCall = typeof(SoftDeleteExtension)
                    .GetMethod(nameof(GetSoftDeleteFilter),
                     BindingFlags.NonPublic | BindingFlags.Static)!
                    .MakeGenericMethod(entityType.ClrType);
                    var filter = methodToCall.Invoke(null, new object[] { });
                    entityType.SetQueryFilter((LambdaExpression)filter!);
                    entityType.AddIndex(entityType.
                         FindProperty(nameof(ISoftDelete.Deleted))!);
                }
            }
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()
            where TEntity : BaseEntity, ISoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => x.Deleted == 0;
            return filter;
        }
    }
}
