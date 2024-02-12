using CleaningRobot.Robot.Positioning;

namespace Tests.Robot.Positioning;

public class GridKeyTest
{
    [Fact]
    public void ShouldBeComparableBuyValue()
    {
        const int x = 1;
        const int y = 2;

        var key1 = new GridKey(x, y);
        var key2 = new GridKey(x, y);
        Assert.Equal(key1, key2);
    }

    [Fact]
    public void ShouldBeCreatedWithTheRightValuesFromInitializer()
    {
        const int x = 1;
        const int y = 2;

        var key = new GridKey { X = x, Y = y };

        Assert.Equal(x, key.X);
        Assert.Equal(y, key.Y);
    }

    [Fact]
    public void ShouldBeCreatedWithTheRightValuesFromConstructor()
    {
        const int x = 1;
        const int y = 2;

        var key = new GridKey(x, y);

        Assert.Equal(x, key.X);
        Assert.Equal(y, key.Y);
    }
}