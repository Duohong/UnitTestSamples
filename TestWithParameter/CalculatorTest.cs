using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace TestWithParameter
{
    public class CalculatorTest
    {
        private Production.Calculator mCalculator = new Production.Calculator();

        [Fact]
        public void Add()
        {
            var result = mCalculator.Add(2, 3);
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(12, 13, 25)]
        [InlineData(13, 14, 27)]
        public void Add_RowData(int a, int b, int sum)
        {
            var result = mCalculator.Add(a, b);
            Assert.Equal(sum, result);
        }

        [Theory]
        [MemberData(nameof(SomeMemberData))]
        public void Add_MemberData(int a, int b, int sum)
        {
            var result = mCalculator.Add(a, b);
            Assert.Equal(sum, result);
        }

        public static IEnumerable<object[]> SomeMemberData
        {
            get
            {
                yield return new object[] { 22, 23, 45 };
                yield return new object[] { 23, 24, 47 };
            }
        }

        [Theory]
        [MemberData(nameof(CartesianProductData))]
        public void Add_CartesianProductData(int a, int b)
        {
            var result = mCalculator.Add(a, b);
            Assert.Equal(a + b, result);
        }

        public static IEnumerable<object[]> CartesianProductData
        {
            get
            {
                var sequences = new object[][] { new object[] { 12, 13 },
                                                 new object[] { 24, 25, 26 } };

                //See http://blogs.msdn.com/b/ericlippert/archive/2010/06/28/computing-a-cartesian-product-with-linq.aspx

                IEnumerable<object[]> emptyProduct = new[] { new object[] { } };

                return sequences.Aggregate(
                    emptyProduct,
                    (accumulator, sequence) =>
                        from accseq in accumulator
                        from item in sequence
                        select accseq.Concat(new[] { item }).ToArray());
            }
        }
    }
}
