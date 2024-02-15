namespace Api.Common;

public static class TimeUtils
{
    public static double MsToSec(long ms)
    {
        return ms * 0.001;
    }
}