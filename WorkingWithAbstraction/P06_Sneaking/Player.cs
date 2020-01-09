using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Player
    {
        public Player()
        {

        }

        public int Row { get; set; }

        public int Col { get; set; }

        internal void Move(char command, Player sam)
        {
            switch (command)
            {
                case 'U':
                    sam.Row--;
                    break;
                case 'D':
                    sam.Row++;
                    break;
                case 'L':
                    sam.Col--;
                    break;
                case 'R':
                    sam.Col++;
                    break;
                default:
                    break;
            }
        }
    }
}
