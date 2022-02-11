using RobotCleaner.Model;
using System;

namespace RobotCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of commands: ");
            var stinNumberOfCommands = Console.ReadLine();
            var numberOfcommands = int.Parse(stinNumberOfCommands);
            
            Console.WriteLine("Starting coordinates: ");
            var stinCoordinates = Console.ReadLine();
            var startX = int.Parse(stinCoordinates.Split(" ")[0]);
            var startY = int.Parse(stinCoordinates.Split(" ")[1]);

            var robot = new Robot(startX, startY);
            
            Console.WriteLine("Where does the robot go?");
            for (var i = 0; i < numberOfcommands; i++)
            {
                var stinCommand = Console.ReadLine();
                var direction = stinCommand.Split(" ")[0].ToUpperInvariant();
                var movements = int.Parse(stinCommand.Split(" ")[1]);
                robot.Move(direction, movements);
            }

            Console.WriteLine($"=> Cleaned: {robot.UniqueCoordinatesCleaned.Count}");
        }
    }
}
