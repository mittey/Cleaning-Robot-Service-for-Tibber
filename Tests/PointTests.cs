using CleaningRobot.Positioning;

namespace Tests;

public class PointTests
{
    [Fact]
    public void ShouldInitializeWithConstructorValues()
    {
        const int x = 1, y = 2;

        var testPoint = new Point(x, y);

        Assert.Equal(x, testPoint.X);
        Assert.Equal(y, testPoint.Y);
    }
}