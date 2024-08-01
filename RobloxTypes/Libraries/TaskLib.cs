﻿namespace Roblox
{
    public static partial class Globals
    {
        public static class task
        {
            /// <summary>Calls/resumes a function/coroutine immediately through the engine scheduler.</summary>
            public static Thread spawn(Delegate f, params object[] args)
            {
                return null!;
            }

            /// <summary>Calls/resumes a function/coroutine immediately through the engine scheduler.</summary>
            public static Thread spawn(Thread thread, params object[] args)
            {
                return null!;
            }

            /// <summary>Calls/resumes a function/coroutine on the next resumption cycle.</summary>
            public static Thread defer(Delegate f, params object[] args)
            {
                return null!;
            }

            /// <summary>Calls/resumes a function/coroutine on the next resumption cycle.</summary>
            public static Thread defer(Thread thread, params object[] args)
            {
                return null!;
            }

            /// <summary>Schedules a function/coroutine to be called/resumed on the next Heartbeat after the given duration (in seconds) has passed, without throttling.</summary>
            public static Thread delay(float duration, Delegate f, params object[] args)
            {
                return null!;
            }

            /// <summary>Schedules a function/coroutine to be called/resumed on the next Heartbeat after the given duration (in seconds) has passed, without throttling.</summary>
            public static Thread delay(float duration, Thread thread, params object[] args)
            {
                return null!;
            }

            /// <summary>Causes the following code to be run in parallel.</summary>
            public static void desynchronize()
            {
            }

            /// <summary>Causes the following code to be run in serial.</summary>
            public static void synchronize()
            {
            }

            /// <summary>Yields the current thread until the next Heartbeat in which the given duration (in seconds) has passed, without throttling.</summary>
            public static float wait(float time)
            {
                return default;
            }

            /// <summary>Cancels a thread, preventing it from being resumed.</summary>
            public static void cancel(Thread thread)
            {
            }
        }
    }
}