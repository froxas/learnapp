using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace learnapp.Helpers
{
    public class FilterExpressionBuilder
    {     
        /// <summary>
        /// Builds an expression to use for to filter entities 
        /// by all properties of type string 
        /// </summary>
        /// <param name="filterText">Text for to filter</param>
        /// <typeparam name="T">Entity to filter</typeparam>
        /// <returns></returns>
        public static Func<T, bool> FilterKey<T>(string filterText)
        {
            ParameterExpression parameter = Expression.Parameter(typeof (T), "p");
            String[] properties = typeof(T)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    //.Where(e => e.PropertyType == typeof(String))
                    .Select(p => p.Name)
                    .ToArray();

            Expression[] propertyExpressions = properties
                .Select(x => !string.IsNullOrEmpty(x) ? GetDeepPropertyExpression(parameter, x) : null)
                .ToArray();

            Expression like = propertyExpressions
                .Select(expression => Expression.Call(expression, typeof (string)
                .GetMethod("ToLower", Type.EmptyTypes)))
                .Select(toLower => Expression.Call(toLower, typeof (string)
                .GetMethod("Contains"), Expression.Constant(filterText.ToLower())))
                .Aggregate<MethodCallExpression, Expression>(null, (current, ex) => BuildOrExpression(current, ex));
            return  Expression.Lambda<Func<T, bool>>(like, parameter).Compile();          
        }
        

        private static Expression BuildOrExpression(
            Expression existingExpression, 
            Expression expressionToAdd)
        {
            if (existingExpression == null)
            {
                return expressionToAdd;
            }
            //Build 'OR' expression for each property
            return Expression.OrElse(existingExpression, expressionToAdd);
        }

       private static Expression GetDeepPropertyExpression(
           Expression initialInstance, 
           string property)
        {
            Expression result = null;
            foreach (string propertyName in property.Split('.'))
            {
                Expression instance = result ?? initialInstance;
                result = Expression.Property(instance, propertyName);
            }
            return result;
        }
        
    }
}