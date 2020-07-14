using System.Collections.Generic;
using RogueSheep;

namespace BurglarOfBabylon
{
    public class BreadthFirstSearch
    {
        private GameGrid<bool> PassabilityGrid { get; }

        private static readonly Point2i[] Directions = { (0, -1), (0, 1), (-1, 0), (1, 0), (1, -1), (-1, -1), (1, 1), (-1, 1) };

        public BreadthFirstSearch(GameGrid<bool> passabilityGrid)
        {
            PassabilityGrid = passabilityGrid;
        }

        public List<Point2i> GetPath(Point2i start, Point2i end)
        {
            var frontier = new Queue<Point2i>();
            frontier.Enqueue(start);
            var cameFrom = new Dictionary<Point2i, Point2i>();

            var current = start;

            while (frontier.Count > 0)
            {
                current = frontier.Dequeue();

                if (current == end)
                {
                    break;
                }

                foreach (var dir in Directions)
                {
                    var neighbor = current + dir;
                    if (PassabilityGrid[neighbor] && !cameFrom.ContainsKey(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                        cameFrom[neighbor] = current;
                    }
                }
            }

            if (current != end)
            {
                return new List<Point2i>();
            }

            var path = new List<Point2i>();
            while (current != start)
            {
                path.Add(current);
                current = cameFrom[current];
            }
            path.Reverse();
            return path;
        }
    }
}
