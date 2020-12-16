using System;
using System.Collections.Generic;
using Xunit;

using TurtleMine;

namespace XUnitTest
{
    public class PositionTest
    {
        private Position pos1;
        private Position pos2;

        public PositionTest()
        {
            pos1 = new Position(1, 2);
            pos2 = new Position(1, 2);
        }
        [Fact]
        public void PositionSatisfyEquals()
        {
            Assert.True(pos1 == pos2);
        }

        [Fact]
        public void PositionGetHashCode()
        {  
            var hc1 = pos1.GetHashCode();
            var hc2 = pos2.GetHashCode();
            Assert.True(hc1 == hc2);
        }

        [Fact]
        public void PositionInHashSet()
        {
            var hash = new HashSet<Position> { pos1, pos2 };
            Assert.True(hash.Count == 1);
        }
    }
}
