namespace FsNunitTest

open NUnit.Framework

[<TestFixture>]
type CalculatorTest () =
    let mCalculator = new Production.Calculator()

    [<SetUp>]
    member this.Setup () =
        ()

    [<Test>]
    member this.AddTest () =
        Assert.AreEqual(mCalculator.Add(2, 3), 5)

    [<Test>]
    member this.FailingTest () =
        Assert.AreEqual(5, 4)

    [<TestCase(3, 4, 7 )>]
    [<TestCase(5, 6, 11)>]
    [<TestCase(5, 6, 12)>]
    member this.Add_Expect (a : int, b : int, expected : int) =
        Assert.AreEqual(expected, mCalculator.Add(a, b));

    [<Test>]
    [<Pairwise>]
    member this.ColumnParameterTest ([<Values(1, 2, 3)>] (i : int), [<Values("a", "b", "c")>] (s : string)) =
        Assert.Greater(i, 0)
