using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static long sum;

        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();

            sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoS = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int[] evilS = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilRow = evilS[0];
                int evilCol = evilS[1];

                Player evil = new Player(evilRow, evilCol);

                MoveEvil(matrix, evil);

                int ivoRow = ivoS[0];
                int ivoCol = ivoS[1];

                Player ivo = new Player(ivoRow, ivoCol);

                MoveIvo(matrix, ivo);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static void MoveIvo(int[,] matrix, Player ivo)
        {
            while (ivo.Row >= 0 && ivo.Col < matrix.GetLength(1))
            {
                if (IsInside(matrix, ivo.Row, ivo.Col))
                {
                    sum += matrix[ivo.Row, ivo.Col];
                }

                ivo.Col++;
                ivo.Row--;
            }
        }

        private static void MoveEvil(int[,] matrix, Player evil)
        {
            while (evil.Row >= 0 && evil.Col >= 0)
            {
                if (IsInside(matrix, evil.Row, evil.Col))
                {
                    matrix[evil.Row, evil.Col] = 0;
                }

                evil.Row--;
                evil.Col--;
            }
        }

        private static bool IsInside(int[,] matrix, int evilRow, int evilCol)
        {
            return evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1);
        }
    }
}
