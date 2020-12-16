using System;

namespace TurtleMine
{
    [Flags]
    public enum Orientation
    {
        North   = 1, // 1 << 0
        West    = 2, // 1 << 1
        South   = 4, // 1 << 2
        East    = 8, // 1 << 3

        NorthWest = North | West,
        SouthWest = South | West,
        NorthEast = North | East,
        SouthEast = South | East
    }

    public enum RotationType
    {
        Left,
        Right
    }
    
    public static class OrientationEx
    {
        public static Orientation Rotate(this Orientation This, RotationType rot)
        {
            var b = (byte)This;
            var res = rot switch
            {
                RotationType.Left => (b << 1) & 0b_0000_1111  | b >> 3,
                RotationType.Right => (b >> 1) & 0b_0000_1111 | (b & 0b0000_0001) << 3,
            };

            return (Orientation)res;
        }

        public static Orientation FromString(string str)
        {
            return str switch
            {
                "N" => Orientation.North,
                "S" => Orientation.South,
                "W" => Orientation.West,
                "E" => Orientation.East,
                "NW" => Orientation.NorthWest,
                "NE" => Orientation.NorthEast,
                "SW" => Orientation.SouthWest,
                "SE" => Orientation.SouthEast,
                _ => throw new NotImplementedException(),
            };
        }
    }

}