using cw13.nwdclasslib;

namespace cw13.nwdxunit;

public class FactorialTests
{
    [Fact]
    public void If_0_Then_1()
    {
        // Arrange
        var factorial = new Factorial();
        int input = 0;
        long expected = 1;

        // Act  
        long result = factorial.Calculate(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void If_1_Then_1()
    {
        // Arrange
        var factorial = new Factorial();
        int input = 1;
        long expected = 1;

        // Act
        long result = factorial.Calculate(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void If_5_Then_120()
    {
        // Arrange
        var factorial = new Factorial();
        int input = 5;
        long expected = 120; // 5! = 5 * 4 * 3 * 2 * 1 = 120

        // Act
        long result = factorial.Calculate(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void If_Minus1_Then_ArgumentException()
    {
        // Arrange
        var factorial = new Factorial();
        int input = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => factorial.Calculate(input));
    }
}