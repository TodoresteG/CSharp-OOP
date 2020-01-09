using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            List<string> readyInput = new List<string>();

            ReadInput(readyInput, size);

            Room room = new Room(size, readyInput);

            Player sam = new Player();

            room.FindSamPosition(sam);

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                char currentCommand = moves[i];

                room.MoveEnemies();

                room.Matrix[sam.Row][sam.Col] = '.';

                if (room.KillerCheck(sam))
                {
                    Console.WriteLine($"Sam died at {sam.Row}, {sam.Col}");
                    Console.WriteLine(room);
                    break;
                }

                sam.Move(currentCommand, sam);

                room.Matrix[sam.Row][sam.Col] = 'S';

                if (room.CheckForNikoladze(sam))
                {
                    Console.WriteLine("Nikoladze killed!");
                    Console.WriteLine(room);
                    break;
                }
            }
        }

        private static void ReadInput(List<string> readyInput, int size)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine();

                readyInput.Add(input);
            }
        }
    }
}
