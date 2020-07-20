namespace HireAProfessional.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    using HireAProfessional.Web.Infrastructure.Enums;

    public static class IQuerableExtentionMethods
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, OrderType orderType)
        {
            string command = orderType == OrderType.Ascending ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(
                                                   typeof(Queryable),
                                                   command,
                                                   new Type[] { type, property.PropertyType },
                                                   source.Expression,
                                                   Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
