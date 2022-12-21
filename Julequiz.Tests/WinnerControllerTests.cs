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
        var result = (Ok<String>) winnerController.RegisterWinnerName(testWinner);

        // Assert
        result.Value.Should().Be(testWinner);
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void RegisterWinnerName_GivenWhenWinnerIsFound_ReturnsConflict()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        winnerController.RegisterWinnerName("Oliver");
        var result = (Conflict<string>) winnerController.RegisterWinnerName("Olivia");

        // Assert
        result.StatusCode.Should().Be(409);
        result.Value.Should().Be("Oliver");
    }

    [Fact]
    public void ResetWinner_ReturnsBadRequest_GivenNoName()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        var result = (BadRequest) winnerController.ResetWinner();

        // Assert
        result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ResetWinner_ReturnsNoContent_GivenName()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        winnerController.RegisterWinnerName("Oliver");
        var result = (NoContent) winnerController.ResetWinner();

        // Assert
        result.StatusCode.Should().Be(204);
        winnerController.WinnerName.Should().Be("");
    }

    [Fact]
    public void GetWinner_ReturnsOkAndWinner_HavingWinner()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        winnerController.RegisterWinnerName("Oliver");
        var result = (Ok<string>) winnerController.GetWinner();

        // Assert
        result.StatusCode.Should().Be(200);
        result.Value.Should().Be("Oliver");
    }

    [Fact]
    public void GetWinner_ReturnsNotFound_HavingNoWinner()
    {
        // Arrange
        var winnerController = new WinnerController();

        // Act
        var result = (NotFound<string>) winnerController.GetWinner();

        // Assert
        result.StatusCode.Should().Be(404);
        result.Value.Should().Be("no winner");
    }
}