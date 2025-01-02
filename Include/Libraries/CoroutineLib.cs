namespace Roblox;

public interface thread
{
}

public static class coroutine
{
    /// <summary>Closes and puts the provided coroutine in a dead state.</summary>
    public static extern (bool, string?) close(thread co);

    /// <summary>Creates a new coroutine, with body f. f must be a Lua function.</summary>
    public static extern thread create(Delegate f);

    /// <summary>Returns true if the coroutine this function is called within can safely yield.</summary>
    public static extern bool isyieldable(thread co);

    /// <summary>Starts or continues the execution of coroutine co.</summary>
    public static extern (bool, object[]) resume(thread co, params object[] args);

    /// <summary>Returns the running coroutine.</summary>
    public static extern thread running();

    /// <summary>Returns the status of coroutine co as a string.</summary>
    public static extern string status(thread co);

    /// <summary>Creates a new coroutine and returns a function that, when called, resumes the coroutine.</summary>
    public static extern TFunc wrap<TFunc>(TFunc f) where TFunc : Delegate;

    /// <summary>Suspends execution of the coroutine.</summary>
    public static extern object[] yield(params object[] args);
}