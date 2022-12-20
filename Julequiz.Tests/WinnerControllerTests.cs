namespace Julequiz.Tests;

public class WinnerControllerTests
{
    [Fact]
    public void RegisterWinnerName_SetsCorrectWinner()
    {
        // Arrange 
        var winnerController = new WinnerController();
        var testWinner = "Oliver";

        // Act
        winnerController.RegisterWinnerName(testWinner);

        // Assert
        winnerController.WinnerName.Should().Be(testWinner);
    }

    [Fact]
    public void RegisterWinnerName_GivenNoNameIsNull()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act

        // Assert
        winnerController.WinnerName.Should().BeNull();
    }

    [Fact]
    public void IsWinnerFound_ReturnsFalse_GivenNoName()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act

        // Assert
        winnerController.IsWinnerFound().Should().BeFalse();
    }
    
    [Fact]
    public void IsWinnerFound_ReturnsTrue_GivenName()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        winnerController.RegisterWinnerName("Oliver");

        // Assert
        winnerController.IsWinnerFound().Should().BeTrue();
    }

    [Fact]
    public void ResetWinner_ReturnsFalse_GivenNoName()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act


        // Assert
        winnerController.ResetWinner().Should().BeFalse();
        winnerController.WinnerName.Should().BeNull();
    }

    [Fact]
    public void ResetWinner_ReturnsTrue_GivenName()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        winnerController.RegisterWinnerName("Oliver");

        // Assert
        winnerController.ResetWinner().Should().BeTrue();
        winnerController.WinnerName.Should().BeNull();
    }
}