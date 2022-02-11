using RobotCleaner.Model;
using Xunit;

namespace RobotCleaner.Specifications
{
    public class TestRobot
    {
        [Theory]
        [InlineData(0, 0, "N", 1000, 1001)]
        [InlineData(0, 0, "S", 1000, 1001)]
        [InlineData(0, 0, "W", 1000, 1001)]
        [InlineData(0, 0, "E", 1000, 1001)]
        public void TestRobotHappyFlow(int startX, int startY, string direction, int movements, int expectedCleaned)
        {
            var robot = new Robot(startX, startY);
            robot.Move(direction, movements);

            Assert.Equal(expectedCleaned, robot.UniqueCoordinatesCleaned.Count);
        }

        [Theory]
        [InlineData(0, 0, "N", 100001, 100001)]
        [InlineData(0, 0, "S", 110000, 100001)]
        [InlineData(0, 0, "W", 120000, 100001)]
        [InlineData(0, 0, "E", 200000, 100001)]
        public void TestRobotBoundFlow(int startX, int startY, string direction, int movements, int expectedCleaned)
        {
            var robot = new Robot(startX, startY);
            robot.Move(direction, movements);

            Assert.Equal(expectedCleaned, robot.UniqueCoordinatesCleaned.Count);
        }

        [Theory]
        [InlineData(0, 0, "N", 2, "S", 2, 3)]
        [InlineData(0, 0, "W", 2, "E", 2, 3)]
        public void TestRobotOverlapCleaningSameAxis(int startX, 
                                                     int startY, 
                                                     string direction1, 
                                                     int movements1,
                                                     string direction2,
                                                     int movements2,
                                                     int expectedCleaned)
        {
            var robot = new Robot(startX, startY);
            robot.Move(direction1, movements1);
            robot.Move(direction2, movements2);

            Assert.Equal(expectedCleaned, robot.UniqueCoordinatesCleaned.Count);
        }

        [Theory]
        [InlineData(0, 0, "N", 2, "S", 2, 4)]
        [InlineData(0, 0, "W", 2, "E", 2, 5)]
        public void TestRobotOverlapCleaningSameAxisWrong(int startX,
                                                          int startY,
                                                          string direction1,
                                                          int movements1,
                                                          string direction2,
                                                          int movements2,
                                                          int expectedCleaned)
        {
            var robot = new Robot(startX, startY);
            robot.Move(direction1, movements1);
            robot.Move(direction2, movements2);

            Assert.NotEqual(expectedCleaned, robot.UniqueCoordinatesCleaned.Count);
        }

        [Theory]
        [InlineData(0, 0, "N", 3, "E", 2, "S", 2, "W", 1, 9)]
        /*  no overlap:
         *  
         *  . . . . . .
         *  . . ____  .
         *  . . | . | .
         *  . . | __| .
         *  . . | . . .
         */
        [InlineData(0, 0, "N", 3, "E", 1, "S", 1, "W", 2, 7)]
        /*  overlap:
         *  
         *  . . . . . .
         *  . . __  . .
         *  . __|_| . .
         *  . . | . . .
         *  . . | . . .
         */
        [InlineData(99999, 0, "E", 4, "N", 3, "W", 1, "S", 1, 7)]
        /*  no overlap and bound:
         *  
         *  . . . . . .
         *  . . . .  __ 
         *  . . . . | |
         *  . . . . . |
         *  . . . . __|
         */
        [InlineData(99999, 0, "E", 4, "N", 3, "W", 1, "S", 3, 8)]
        /*  overlap and bound:
         *  
         *  . . . . . .
         *  . . . .  __ 
         *  . . . . | |
         *  . . . . | |
         *  . . . . |_|
         */
        public void TestRobotAllDirections(int startX,
                                           int startY,
                                           string direction1,
                                           int movements1,
                                           string direction2,
                                           int movements2,
                                           string direction3,
                                           int movements3,
                                           string direction4,
                                           int movements4,
                                           int expectedCleaned)
        {
            var robot = new Robot(startX, startY);
            robot.Move(direction1, movements1);
            robot.Move(direction2, movements2);
            robot.Move(direction3, movements3);
            robot.Move(direction4, movements4);

            Assert.Equal(expectedCleaned, robot.UniqueCoordinatesCleaned.Count);
        }
    }
}
