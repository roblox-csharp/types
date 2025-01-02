namespace Roblox;

public static class os
{
    /// <summary>Returns a high-precision amount of CPU time used by Lua in seconds, intended for use in benchmarking.</summary>
    public static extern double clock();

    /// <summary>Returns how many seconds have passed since the Unix epoch (1 January 1970, 00:00:00) under current UTC time.</summary>
    public static extern uint time(time_t? time = null);

    /// <summary>Returns the number of seconds from t1 to t2, assuming the arguments are correctly casted to the time_t format.</summary>
    public static extern uint difftime(float t2, float t1);

    /// <summary>Formats the given string with date/time information based on the given time (or if not provided, the value returned by os.time).</summary>
    public static extern string date(string? formatString = null, float? time = null);

    /// <summary>Formats the given string with date/time information based on the given time (or if not provided, the value returned by os.time).</summary>
    public static extern time_t date(string formatString, float time);
}