using System;
using System.Collections.Generic;

namespace RobotCleaner.Model
{
    public class Robot
    {
        public Coordinates CurrentCoordinate { get; set; }
        public ICollection<Coordinates> UniqueCoordinatesCleaned { get; } = new List<Coordinates>();

        public Robot(int startX, int startY)
        {
            CurrentCoordinate = new Coordinates(startX, startY);
            UniqueCoordinatesCleaned.Add(CurrentCoordinate);
        }

        public void Move(string direction, int movements)
        {
            if (direction == "N")
            {
                MoveNorth(movements);
            }

            if (direction == "S")
            {
                MoveSouth(movements);
            }

            if (direction == "W")
            {
                MoveWest(movements);
            }

            if (direction == "E")
            {
                MoveEast(movements);
            }
        }

        private void MoveNorth(int movements)
        {
            for (int i = 1; i <= movements; i++)
            {
                if (CurrentCoordinate.Y + i > Constants.Bound)
                {
                    CurrentCoordinate = new Coordinates(CurrentCoordinate.X, Constants.Bound);
                    return;
                }

                var newCoordinate = new Coordinates(CurrentCoordinate.X, CurrentCoordinate.Y + i);
                if (!UniqueCoordinatesCleaned.Contains(newCoordinate))
                {
                    UniqueCoordinatesCleaned.Add(newCoordinate);
                }
            }
            CurrentCoordinate = new Coordinates(CurrentCoordinate.X, CurrentCoordinate.Y + movements);
        }

        private void MoveSouth(int movements)
        {
            for (int i = 1; i <= movements; i++)
            {
                if (CurrentCoordinate.Y - i < Constants.MinusBound)
                {
                    CurrentCoordinate = new Coordinates(CurrentCoordinate.X, Constants.MinusBound);
                    return;
                } 

                var newCoordinate = new Coordinates(CurrentCoordinate.X, CurrentCoordinate.Y - i);
                if (!UniqueCoordinatesCleaned.Contains(newCoordinate))
                {
                    UniqueCoordinatesCleaned.Add(newCoordinate);
                }
            }
            CurrentCoordinate = new Coordinates(CurrentCoordinate.X, CurrentCoordinate.Y - movements);
        }

        private void MoveWest(int movements)
        {
            for (int i = 1; i <= movements; i++)
            {
                if (CurrentCoordinate.X - i < Constants.MinusBound)
                {
                    CurrentCoordinate = new Coordinates(Constants.MinusBound, CurrentCoordinate.Y);
                    return;
                }

                var newCoordinate = new Coordinates(CurrentCoordinate.X - i, CurrentCoordinate.Y);
                if (!UniqueCoordinatesCleaned.Contains(newCoordinate))
                {
                    UniqueCoordinatesCleaned.Add(newCoordinate);
                }
            }
            CurrentCoordinate = new Coordinates(CurrentCoordinate.X - movements, CurrentCoordinate.Y);
        }

        private void MoveEast(int movements)
        {
            for (int i = 1; i <= movements; i++)
            {
                if (CurrentCoordinate.X + i > Constants.Bound)
                {
                    CurrentCoordinate = new Coordinates(Constants.Bound, CurrentCoordinate.Y);
                    return;
                }

                var newCoordinate = new Coordinates(CurrentCoordinate.X + i, CurrentCoordinate.Y);
                if (!UniqueCoordinatesCleaned.Contains(newCoordinate))
                {
                    UniqueCoordinatesCleaned.Add(newCoordinate);
                }
            }
            CurrentCoordinate = new Coordinates(CurrentCoordinate.X + movements, CurrentCoordinate.Y);
        }
    }
}
