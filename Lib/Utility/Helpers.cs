using System;
using System.Collections.Generic;
using System.Linq;

namespace TurtleMine
{
    public static class Helpers
    {
        public static void Deconstruct(this IEnumerable<string> items, out int t0, out int t1)
        {
            var array = items.Take(2).ToArray();
            t0 = int.Parse(array[0]);
            t1 = int.Parse(array[1]);
        }

        public static void Deconstruct(this IEnumerable<string> items, out int t0, out int t1, out string t2)
        {
            var array = items.Take(3).ToArray();
            t0 = int.Parse(array[0]);
            t1 = int.Parse(array[1]);
            t2 = array[2];
        }
    }
}