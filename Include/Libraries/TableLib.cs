namespace Roblox
{
    public static class table
    {
        /// <summary>
        /// <para>Sets the value for all keys within the given dictionary to default. This causes the Count property to return 0.</para>
        /// <para>The allocated capacity of the dictionary's internal storage is maintained, allowing efficient re-use of the space.</para>
        /// <para>This method does not delete/destroy the dictionary provided. It is meant to be used specifically for dictionaries that are to be re-used.</para>
        /// </summary>
        public static void clear(object t)
        {
        }

        /// <summary>
        /// <para>Creates a list with the array portion allocated to the given number of elements, optionally filled with the given value.</para>
        /// <para>If you are inserting into large array-like lists and are certain of a reasonable upper limit to the number of elements,  it's recommended to use this method to initialize the list.</para>
        /// <para>This ensures the list's internal storage is sufficiently sized, as resizing it can be expensive. For small quantities, this is typically not noticeable.</para>
        /// </summary>
        public static T[] create<T>(int count, T? value = default)
        {
            return null!;
        }

        /// <summary>
        /// <para>Sorts list elements in a given order, in-place, from list[0] to list[list.Count - 1].</para>
        /// <para>Comp is a function that receives two list elements and returns true when the first element must come before the second in the final order (so that not comp(list[i+1], list[i]) will be true after the sort).</para>
        /// </summary>
        public static void sort<T>(T[] t, Func<T, T, bool>? comp = null)
        {
        }

        /// <summary>
        /// <para>Makes the list read-only and prohibits all further modifications.</para>
        /// <para>This freezing effect is shallow, which means that you can write to a list within a frozen list.</para>
        /// <para>To deep freeze a list, call this method recursively on all of the descending lists.</para>
        /// </summary>
        public static T[] freeze<T>(T t)
        {
            return null!;
        }

        /// <summary>Returns whether or not the list is frozen.</summary>
        public static bool isfrozen<T>(T t)
        {
            return default;
        }

        /// <summary>
        /// <para>Takes an object and returns a new object that has the same keys, values and references.</para>
        /// <para>The cloning is shallow - meaning that any reference values in the clone will reference the same objects as the parent.</para>
        /// </summary>
        public static T clone<T>(T t)
        {
            return default!;
        }

        /// <summary>
        /// <para>Takes an object and returns a new object that has the same keys, values and references.</para>
        /// <para>The cloning is shallow - meaning that any reference values in the clone will reference the same objects as the parent.</para>
        /// </summary>
        public static T[] clone<T>(T[] t)
        {
            return null!;
        }

        public static void insert<T>(T[] t, T value)
        {
        }

        public static void insert<T>(T[] t, uint index, T value)
        {
        }

        public static T? remove<T>(T[] t, uint? index = null)
        {
            return default;
        }

        public static T[] move<T>(T[] src, uint a, uint b, uint t, T[]? dst = null!)
        {
            return default!;
        }

        public static string concat(object[] t, string? sep = null, uint? i = null, uint? j = null)
        {
            return default!;
        }

        public static uint? find<T>(T[] t, T value, uint? init = null)
        {
            return default;
        }
    }
}