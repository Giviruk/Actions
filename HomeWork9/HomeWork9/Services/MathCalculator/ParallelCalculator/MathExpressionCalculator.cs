﻿using System.Linq.Expressions;
using HomeWork9.Services.MathCalculator.MathExpressionGraph;

namespace HomeWork9.Services.MathCalculator.ParallelCalculator;

public class MathExpressionCalculator : IMathExpressionCalculator
{
    public async Task<double> CalculateAsync(Expression current,
        IReadOnlyDictionary<Expression, MathExpression> dependencies)
    {
        if (!dependencies.ContainsKey(current))
        {
            return double.Parse(current.ToString());
        }
        
        await Task.Delay(1000);
        var left = Task.Run(() => 
            CalculateAsync(dependencies[current].LeftExpression, dependencies));
        var right = Task.Run(() => 
            CalculateAsync(dependencies[current].RightExpression, dependencies));

        var results = await Task.WhenAll(left, right);
        return CalculateExpression(results[0], current.NodeType, results[1]);
    }

    private static double CalculateExpression(double v1, ExpressionType expressionType, double v2)
    {
        return expressionType switch
        {
            ExpressionType.Add => v1 + v2,
            ExpressionType.Subtract => v1 - v2,
            ExpressionType.Divide => v2 == 0 ? double.NaN : v1 / v2,
            ExpressionType.Multiply => v1 * v2,
        };
    }
}