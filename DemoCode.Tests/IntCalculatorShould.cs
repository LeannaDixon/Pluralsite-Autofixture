using System;
using AutoFixture;
using DemoCode.Calculator;
using FluentAssertions;
using NUnit.Framework;
using AutoFixture.NUnit3;

namespace DemoCode.Tests
{
    [TestFixture]
    public class IntCalculatorShould
    {
        // Autofixture.NUnit3 only gives positive values, so we need to use InlineAutoData to sepecify values <=0
        [Test, AutoData]
        [InlineAutoData(0)]
        [InlineAutoData(-5)]
        public void Add(int a, int b)
        {
            ICalculator<int> sut = new IntCalculator();

            sut.Add(a);
            sut.Add(b);

            sut.Value.Should().Be(a+b);
        }
    }
}

