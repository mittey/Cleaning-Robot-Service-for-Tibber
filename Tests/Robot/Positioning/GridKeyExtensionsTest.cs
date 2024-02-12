using CleaningRobot.Robot.Positioning;

namespace Tests.Robot.Positioning;

public class GridKeyExtensionsTest
{
    [Fact]
    public void ShouldMapPointToGridKeyProperly()
    {
        const int x = 1;
        const int y = 2;
        var p = new Point(x, y);

        var key = p.ToGridKey();

        Assert.Equal(x, key.X);
        Assert.Equal(y, key.Y);
    }
}