using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public class MapNavigator
    {
        private (string instructions, Dictionary<string, (string Left, string Right)> map) ReadFile(string[] rows)
        {
            var s = rows.First();
            var valueTuples = new Dictionary<string, (string Left, string Right)>();

            for (int i = 1; i < rows.Length; i++)
            {
                var parts = rows[i].Split(new[] { " = (", ", ", ")" }, StringSplitOptions.None);
                valueTuples[parts[0]] = (parts[1], parts[2]);
            }

            return (s, valueTuples);
        }

        public int StepsToEscape(string[] rows)
        {
            var (instructions, map) = ReadFile(rows);

            var currentNode = "AAA";
            var steps = 0;
            var instructionIndex = 0;

            while (currentNode != "ZZZ")
            {
                if (instructionIndex >= instructions.Length)
                {
                    instructionIndex = 0;
                }

                var direction = instructions[instructionIndex++];
                currentNode = direction == 'L' ? map[currentNode].Left : map[currentNode].Right;
                steps++;
            }

            return steps;
        }

        public int GhostStepsToEscape(string[] rows)
        {
            var (instructions, map) = ReadFile(rows);

            var activeNodes = new Dictionary<string, string>();
            foreach (var node in map.Keys)
            {
                if (node.EndsWith("A"))
                {
                    activeNodes[node] = node; // Initialize active nodes
                }
            }

            var steps = 0;
            var instructionIndex = 0;
            bool allNodesReachedZ = false;

            while (!allNodesReachedZ)
            {
                if (instructionIndex >= instructions.Length)
                {
                    instructionIndex = 0; // Repeat the instructions
                }

                var direction = instructions[instructionIndex++];
                var nextActiveNodes = new Dictionary<string, string>();

                foreach (var nextNode in activeNodes.Values.Select(node => direction == 'L' ? map[node].Left : map[node].Right))
                {
                    nextActiveNodes[nextNode] = nextNode;
                }

                activeNodes = nextActiveNodes;
                steps++;

                allNodesReachedZ = activeNodes.Keys.All(node => node.EndsWith("Z"));
            }

            return steps;
        }
    }
}
