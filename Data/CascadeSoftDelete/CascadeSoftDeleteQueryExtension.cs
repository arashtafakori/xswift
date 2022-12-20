using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace CoreX.Structure
{
    public static class CascadeSoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
            this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ICascadeSoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var methodToCall = typeof(CascadeSoftDeleteQueryExtension)
                    .GetMethod(nameof(GetSoftDeleteFilter),
                     BindingFlags.NonPublic | BindingFlags.Static)!
                    .MakeGenericMethod(entityType.ClrType);
                    var filter = methodToCall.Invoke(null, new object[] { });
                    entityType.SetQueryFilter((LambdaExpression)filter!);
                    entityType.AddIndex(entityType.
                         FindProperty(nameof(ICascadeSoftDelete.SoftDeleteLevel))!);
                }
            }
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()
            where TEntity : class, ICascadeSoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => x.SoftDeleteLevel == 0;
            return filter;
        }
    }
}
