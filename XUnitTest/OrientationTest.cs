using Xunit;

using TurtleMine;

namespace XUnitTest
{
    public class OrientationTest
    {
        [Fact]
        public void Rotates()
        {
            Assert.True(Orientation.North.Rotate(RotationType.Left) == Orientation.West);
            Assert.True(Orientation.West.Rotate(RotationType.Left) == Orientation.South);
            Assert.True(Orientation.South.Rotate(RotationType.Left) == Orientation.East);
            Assert.True(Orientation.East.Rotate(RotationType.Left) == Orientation.North);

            Assert.True(Orientation.North.Rotate(RotationType.Right) == Orientation.East);
            Assert.True(Orientation.East.Rotate(RotationType.Right) == Orientation.South);
            Assert.True(Orientation.South.Rotate(RotationType.Right) == Orientation.West);
            Assert.True(Orientation.West.Rotate(RotationType.Right) == Orientation.North);

            Assert.True(Orientation.NorthWest.Rotate(RotationType.Left) == Orientation.SouthWest);
            Assert.True(Orientation.SouthWest.Rotate(RotationType.Left) == Orientation.SouthEast);
            Assert.True(Orientation.SouthEast.Rotate(RotationType.Left) == Orientation.NorthEast);
            Assert.True(Orientation.NorthEast.Rotate(RotationType.Left) == Orientation.NorthWest);

            Assert.True(Orientation.NorthWest.Rotate(RotationType.Right) == Orientation.NorthEast);
            Assert.True(Orientation.NorthEast.Rotate(RotationType.Right) == Orientation.SouthEast);
            Assert.True(Orientation.SouthEast.Rotate(RotationType.Right) == Orientation.SouthWest);
            Assert.True(Orientation.SouthWest.Rotate(RotationType.Right) == Orientation.NorthWest);
        } 
    }
}
