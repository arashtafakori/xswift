using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace XSwift.Mvc
{
    public static class SelectListExtensions
    {
        public static List<SelectListItem> ToSelectList<T, TKey, TValue>(
            this IEnumerable<T> items,
            Expression<Func<T, TKey>> value,
            Expression<Func<T, TValue>> text)
        {
            var valueFunc = value.Compile();
            var textFunc = text.Compile();

            return items.Select(item => new SelectListItem
            {
                Value = valueFunc(item)!.ToString(),
                Text = textFunc(item)!.ToString()
            }).ToList();
        }
    }
}
