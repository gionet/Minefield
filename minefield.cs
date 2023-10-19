﻿using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        // Edit your n*m grid
        // 'O' = path
        // '#' = minefield
        char[][] field = new char[][] {
            new char[] { '#', 'O', '#', '#', '#' },
            new char[] { '#', 'O', 'O', '#', 'O' },
            new char[] { 'O', '#', '#', 'O', 'O' },
            new char[] { 'O', '#', '#', 'O', '#' },
            new char[] { '#', '#', 'O', '#', 'O' },
            new char[] { '#', 'O', '#', '#', '#' }
        };

        // Define starting point
        int startRow = 0;
        int startCol = -1;

        // Search for starting point (entrance)
        for (int col = 0; col < field[0].Length; col++)
        {
            if (field[startRow][col] == 'O')
            {
                startCol = col;
                break;
            }
        }

        // If no entrance
        if (startCol == -1)
        {
            Console.WriteLine("No starting point found in row 0");
        }
        else
        {
            Tuple< List<Tuple<int, int>>, List<Tuple<int, int>> > safePath = FindSafePath(field, startRow, startCol);


            if (safePath != null)
            {
                List<Tuple<int, int>> path = safePath.Item1;
                List<Tuple<int, int>> ally = safePath.Item2;

                Console.WriteLine("CROSSING MINEFIELD COMPLETED");
                Console.WriteLine("Totoshka's Path:");
                foreach (var step in path)
                {
                    Console.WriteLine($"({step.Item1}, {step.Item2})");
                }
                Console.WriteLine("Ally's Path:");
                foreach (var step in ally)
                {
                    Console.WriteLine($"({step.Item1}, {step.Item2})");
                }
            }
            else
            {
                Console.WriteLine("No safe path found");
            }
        }
    }

    public static Tuple<List<Tuple<int, int>>, List<Tuple<int, int>>> FindSafePath(char[][] field, int startRow, int startCol)
    {
        // 8 moving directions (Horizontal, Vertical, Diagonal)
        // Movement Priority: down-left > down > down-right > left > right > up-left > up > up-right 
        Tuple<int, int>[] directions = new Tuple<int, int>[]
        {
            new Tuple<int, int>(1, -1),
            new Tuple<int, int>(1, 0),
            new Tuple<int, int>(1, 1),
            new Tuple<int, int>(0, -1),
            new Tuple<int, int>(0, 1),
            new Tuple<int, int>(-1, -1),
            new Tuple<int, int>(-1, 0),
            new Tuple<int, int>(-1, 1)
        };
        int rows = field.Length;
        int cols = field[0].Length;
        Dictionary<Tuple<int, int>, bool> visited = new Dictionary<Tuple<int, int>, bool>();
        List<Tuple<int, int>> pathAlly = new List<Tuple<int, int>>();
        List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        bool DFS(int row, int col, int allyRow, int allyCol)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || visited.ContainsKey(new Tuple<int, int>(row, col)) || field[row][col] == '#')
            {
                return false;
            }

            // Save visited platform into stack
            visited[new Tuple<int, int>(row, col)] = true;
            path.Add(new Tuple<int, int>(row, col));

            // Ally always behind Toto by 1
            if (path.Count > 1)
            {
                pathAlly.Add(new Tuple<int, int>(allyRow, allyCol));
            }

            // Goal: if reached last row
            if (row == rows - 1)
            {
                return true;
            }

            // Attempt all 8 directions
            foreach (var direction in directions)
            {
                int newRow = row + direction.Item1;
                int newCol = col + direction.Item2;
                int newAllyRow = row;
                int newAllyCol = col;

                // Return true if the next potential step is clear
                if (DFS(newRow, newCol, newAllyRow, newAllyCol))
                {
                    return true;
                }
            }

            // If Toto path exhausted, pop Ally first, then Toto
            if (pathAlly.Count > 0 && path.Count > 0)
            {
                pathAlly.RemoveAt(pathAlly.Count - 1);
            }
            path.RemoveAt(path.Count - 1);

            // To check for collisions (Toto and Ally != the same spot)
            if (path.Count > 0 && pathAlly.Count > 0 && path[path.Count - 1].Equals(pathAlly[pathAlly.Count - 1]))
            {
                Console.WriteLine("Totoshka and Ally collided!");
                return false;
            }

            return false;
        }

        // Return Toto and Ally path if true    
        if (DFS(startRow, startCol, -1, -1))
        {
            return new Tuple< List<Tuple<int, int>>, List<Tuple<int, int>>>(path, pathAlly);
        }
        else
        {
            return null;
        }
        
        //throw new NotImplementedException();
    }
}