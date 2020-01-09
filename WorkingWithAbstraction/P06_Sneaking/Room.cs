using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Room
    {
        private char[][] matrix;

        public Room(int rows, List<string> input)
        {
            this.Matrix = new char[rows][];
            this.InitializeMatrix(input);
        }

        public char[][] Matrix { get; set; }

        private void InitializeMatrix(List<string> input)
        {
            for (int row = 0; row < this.Matrix.Length; row++)
            {
                var line = input[row];

                this.Matrix[row] = new char[line.Length];

                for (int col = 0; col < line.Length; col++)
                {
                    this.Matrix[row][col] = line[col];
                }
            }
        }

        internal void MoveEnemies()
        {
            for (int row = 0; row < this.Matrix.Length; row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == 'b')
                    {
                        if (IsInside(row, col + 1))
                        {
                            this.Matrix[row][col] = '.';
                            this.Matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            this.Matrix[row][col] = 'd';
                        }
                    }
                    else if (this.Matrix[row][col] == 'd')
                    {
                        if (IsInside(row, col - 1))
                        {
                            this.Matrix[row][col] = '.';
                            this.Matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            this.Matrix[row][col] = 'b';
                        }
                    }
                }
            }
        }

        internal bool CheckForNikoladze(Player sam)
        {
            for (int row = 0; row < this.Matrix.Length; row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == 'N' && sam.Row == row)
                    {
                        this.Matrix[row][col] = 'X';
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Matrix)
            {
                sb.AppendLine(string.Join("", item));
            }

            return sb.ToString();
        }

        internal bool KillerCheck(Player sam)
        {
            for (int row = 0; row < this.Matrix.Length; row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == 'b')
                    {
                        if (sam.Col > col && row == sam.Row)
                        {
                            this.Matrix[sam.Row][sam.Col] = 'X';

                            return true;
                        }
                    }
                    else if (this.Matrix[row][col] == 'd')
                    {
                        if (sam.Col < col && row == sam.Row)
                        {
                            this.Matrix[sam.Row][sam.Col] = 'X';

                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool IsInside(int row, int col)
        {
            return row >= 0 && row < this.Matrix.Length && col >= 0 && col < this.Matrix[row].Length;
        }

        internal void FindSamPosition(Player sam)
        {
            for (int row = 0; row < this.Matrix.Length; row++)
            {
                for (int col = 0; col < this.Matrix[row].Length; col++)
                {
                    if (this.Matrix[row][col] == 'S')
                    {
                        sam.Row = row;
                        sam.Col = col;
                    }
                }
            }
        }
    }
}
