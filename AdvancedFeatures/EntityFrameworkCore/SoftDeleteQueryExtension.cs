using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Artaco.Infrastructure.CoreX
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
            this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var methodToCall = typeof(SoftDeleteQueryExtension)
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
            where TEntity : class, ISoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => x.Deleted == 0;
            return filter;
        }
    }
}
