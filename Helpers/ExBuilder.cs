using System;
using System.Linq;
using System.Linq.Expressions;
using learnapp.Model;

namespace learnapp.Helpers
{
    public class ExBuilder
    {
        public static Func<Employee, bool> CompiledLabda() {
               // create a parameter expression
                var parameterExpression = Expression.Parameter(typeof(Employee));

                // create expresion constant
                var constant = Expression.Constant("Vaidas");
                var constant1 = Expression.Constant("Developer");

                // create a property expression
                var property = Expression.Property(parameterExpression, "FirstName");
                var property1 = Expression.Property(parameterExpression, "Function");

                // bring the expression constant and property together
                var expression = Expression.Equal(property, constant);
                var expression1 = Expression.Equal(property1, constant1);

                // joining the two expressions:
                expression = Expression.Or(expression, expression1);

                // create a lambda expression
                var lambda = Expression
                    .Lambda<Func<Employee, bool>>(expression, parameterExpression);

                // compile expresion
                var compiledLambda = lambda.Compile(); 
                
                return compiledLambda;               
        }
    }
}