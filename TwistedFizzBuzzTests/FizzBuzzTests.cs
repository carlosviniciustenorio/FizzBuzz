using TwistedFizzBuzz;

namespace TwistedFizzBuzzTests;

public class FizzBuzzGeneratorTests
{
    /// <summary>
    /// Tests the standard FizzBuzz behavior where:
    /// - Multiples of 3 return "Fizz"
    /// - Multiples of 5 return "Buzz"
    /// - Multiples of both 3 and 5 return "FizzBuzz"
    /// - Other numbers return their string representation
    /// </summary>
    [Fact]
    public void TestFizzBuzzRange_Standard()
    {
        // Arrange
        var fizzBuzz = new FizzBuzzGenerator();
        
        // Act
        var result = fizzBuzz.GetFizzBuzzRange(1, 15);
        
        // Assert
        Assert.Equal("1", result[0]); 
        Assert.Equal("2", result[1]); 
        Assert.Equal("Fizz", result[2]);
        Assert.Equal("Buzz", result[4]);
        Assert.Equal("FizzBuzz", result[14]);
    }

    /// <summary>
    /// Tests FizzBuzz with custom rules:
    /// - Multiples of 5 return "Foo"
    /// - Multiples of 7 return "Bar"
    /// - Multiples of both 5 and 7 return "FooBar"
    /// </summary>
    [Fact]
    public void TestFizzBuzzRange_CustomRules()
    {
        // Arrange - Custom rules dictionary
        var customRules = new Dictionary<int, string>
        {
            { 5, "Foo" },
            { 7, "Bar" }
        };
        
        var fizzBuzz = new FizzBuzzGenerator(customRules);
        
        // Act
        var result = fizzBuzz.GetFizzBuzzRange(new List<int> { 10, 14, 35 });
        
        // Assert
        Assert.Equal("Foo", result[0]);  
        Assert.Equal("Bar", result[1]); 
        Assert.Equal("FooBar", result[2]);
    }

    /// <summary>
    /// Tests FizzBuzz behavior with a non-sequential list of numbers:
    /// - Includes both positive and negative numbers
    /// - Checks standard rules (multiples of 3 and 5)
    /// </summary>
    [Fact]
    public void TestFizzBuzzRange_NonSequentialNumbers()
    {
        // Arrange
        var fizzBuzz = new FizzBuzzGenerator();
        
        // Act
        var result = fizzBuzz.GetFizzBuzzRange(new List<int> { -5, 6, 300, 12, 15 });
        
        // Assert
        Assert.Equal("Buzz", result[0]);  
        Assert.Equal("Fizz", result[1]); 
        Assert.Equal("FizzBuzz", result[2]);
        Assert.Equal("Fizz", result[3]);  
        Assert.Equal("FizzBuzz", result[4]);
    }
}
