using Rocket.Library.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.Library
{
    public class Program
    {
        public Area LandingArea { get; set; }
        public Area Platform { get; set; }
        public Stack<Rocket.Library.Models.Rocket> LandedRockets { get; set; }

        public Program(Area landingArea, Area plataform)
        {
            LandingArea = landingArea;
            Platform = plataform;
            LandedRockets = new();
        }

        public string RocketCanLand(int x, int y)
        {
            if (IsOutOfPlatform(x, y))
                return "out of platform";

            if (IsEqualLastChecked(x, y) || IsInvalidPositionToLand(x , y) || IsPreviously(x, y))
                return "clash";

            LandedRockets.Push(new Models.Rocket 
            { 
                Position = new Coordinate
                {
                    X = x,
                    Y = y
                }
            });

            return "ok for landing";
        }

        private bool IsOutOfPlatform(int x, int y)
        {
            return !(x >= Platform.CoordinateX.X && y <= Platform.CoordinateY.Y);
        }

        private bool IsEqualLastChecked(int x, int y)
        {
            if(LandedRockets.Count > 0)
                return x == LandedRockets.Peek().Position.X && y == LandedRockets.Peek().Position.Y;

            return false;
        }

        private bool IsPreviously(int x, int y)
        {
            if (LandedRockets.Any(c => (c.Position.X == (x + 1) || c.Position.X == (x - 1))))
                return true;

            if (LandedRockets.Any(c => (c.Position.Y == (y + 1) || c.Position.Y == (y - 1))))
                return true;

            return false;
        }

        private bool IsInvalidPositionToLand(int x, int y)
        {
            foreach (var rocket in LandedRockets)
            {
                if (rocket.Position.X == x && rocket.Position.Y == y)
                    return true;
                if (rocket.Position.X == (x - 1) || rocket.Position.X == (x + 1))
                    return true;
                if (rocket.Position.Y == (y - 1) || rocket.Position.Y == (y + 1))
                    return true;
            }
            return false;
        }
    }
}
