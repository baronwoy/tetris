using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        // Create a two-dimensional array
        private readonly int[,] grid;

        // Number of Rows
        public int Rows { get; }

        // Number of Columns
        public int Columns { get; }

        // Defining an index to provide easy access to grid array
        public int this[int r,int c]
        {
            get => grid[r,c];
            set => grid[r,c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        // check if a given row/column is inside grid
        public bool IsInside(int r,int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r,int c)
        {
            return IsInside(r,c) && grid[r, c] == 0;

        }

        public bool isRowFull(int r)
        {
            for  (int c = 0; c < Columns; c++) 
            { 
                if (grid[r,c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // function to check if a row is empty
        public bool isRowEmpty(int r)
        { 
            for (int c = 0;c < Columns; c++)
            {
                if (grid[r,c] != 0)
                {
                    return false;
                }
                
            }
            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r,c] = 0;
            }

        }

        private void MoveRowDown(int r, int numRows)
        {
            for (int c=0; c< Columns; c++)
            {
                grid[r+numRows, c] = grid[r,c];
                grid[r, c] = 0;
            }
        }

        public int clearFullRows()
        {
            int cleared = 0;

            for (int r = Rows-1; r >=0; r--)
            {
                if (isRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }

            }
            return cleared;
        }
    }
}
