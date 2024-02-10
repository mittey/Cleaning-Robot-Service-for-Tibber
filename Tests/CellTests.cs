using CleaningRobot.Positioning;

namespace Tests;

public class CellTests
{
    [Fact]
    public void ShouldBeCreatedInNonVisitedState()
    {
        var testCell = new Cell();

        Assert.False(testCell.Visited);
    }
}