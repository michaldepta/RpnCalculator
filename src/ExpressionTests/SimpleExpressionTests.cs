﻿using Expressions;
using Expressions.Operators;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExpressionTests
{
    [TestFixture]
    public class SimpleExpressionTests
    {
        [Test]
        public void ReturnsLoneArgumentsValue()
        {
            var number = 1234.567;
            var tokens = new Token[] { new Argument(number) };

            Assert.AreEqual(number, Calculate(tokens));
        }

        [Test]
        public void CalculatesSimpleSum()
        {
            var tokens = new Token[]
            {
                new Argument(4),
                new Argument(5),
                new SumOperator()
            };

            Assert.AreEqual(9, Calculate(tokens));
        }

        private double Calculate(IEnumerable<Token> expressionTokens)
        {
            var expression = new RpnExpression(expressionTokens);
            return expression.CalculateResult();
        }
    }
}