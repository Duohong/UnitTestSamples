using System;
using System.Collections;

using NUnit.Framework.Constraints;

namespace NUnit.Framework.Tests
{
    [TestFixture]
    public class ValuesSyntaxTests : AssertionHelper
    {
        [Test, Sequential]
        public void SequentialValues([Values("A", "B")] string s,
                                     [Values(1, 2, 3)] int i)
        {
            // will be called 3 times
            // SequentialValues("A", 1)
            // SequentialValues("B", 2)
            // SequentialValues(null, 3)
        }

        [Test, Combinatorial]
        public void CombinatorialValues([Values("A", "B")] string s,
                                        [Values(1, 2, 3)] int i)
        {
            // will be called 6 times
            // CombinatorialValues("A", 1)
            // CombinatorialValues("A", 2)
            // CombinatorialValues("A", 3)
            // CombinatorialValues("B", 1)
            // CombinatorialValues("B", 2)
            // CombinatorialValues("B", 3)
        }

        [Test, Pairwise]
        public void PairwiseValues([Values("A", "B")] string s,
                                   [Values(1, 2, 3)] int i,
                                   [Values("y", "z")] string x)
        {
            // will be called only 6 times, instead of 12 times 
            // PairwiseValues("A", 1, "y")
            // PairwiseValues("A", 2, "y")
            // PairwiseValues("A", 3, "z")
            // PairwiseValues("B", 1, "z")
            // PairwiseValues("B", 2, "z")
            // PairwiseValues("B", 3, "y")
        }

        [TestCase("A", 1)]
        [TestCase("B", 2)]
        public void TestCase(string s, int i)
        {
            // will be called 2 times
            // SequentialValues("A", 1)
            // SequentialValues("B", 2)
        }
    }
}
