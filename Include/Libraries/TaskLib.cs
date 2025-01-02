namespace Roblox;

public static class task
{
    /// <summary>Calls/resumes a function/coroutine immediately through the engine scheduler.</summary>
    public static extern thread spawn(Delegate f, params object[] args);

    /// <summary>Calls/resumes a function/coroutine immediately through the engine scheduler.</summary>
    public static extern thread spawn(thread thread, params object[] args);

    /// <summary>Calls/resumes a function/coroutine on the next resumption cycle.</summary>
    public static extern thread defer(Delegate f, params object[] args);

    /// <summary>Calls/resumes a function/coroutine on the next resumption cycle.</summary>
    public static extern thread defer(thread thread, params object[] args);

    /// <summary>Schedules a function/coroutine to be called/resumed on the next Heartbeat after the given duration (in seconds) has passed, without throttling.</summary>
    public static extern thread delay(float duration, Delegate f, params object[] args);

    /// <summary>Schedules a function/coroutine to be called/resumed on the next Heartbeat after the given duration (in seconds) has passed, without throttling.</summary>
    public static extern thread delay(float duration, thread thread, params object[] args);

    /// <summary>Causes the following code to be run in parallel.</summary>
    public static extern void desynchronize();

    /// <summary>Causes the following code to be run in serial.</summary>
    public static extern void synchronize();

    /// <summary>Yields the current thread until the next Heartbeat in which the given duration (in seconds) has passed, without throttling.</summary>
    public static extern float wait(float time);

    /// <summary>Cancels a thread, preventing it from being resumed.</summary>
    public static extern void cancel(thread thread);
}