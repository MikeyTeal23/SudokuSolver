using System;
using System.Collections.Generic;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {


        }

        public static List<int> createStartConfiguration()
        {
            List<int> sudokuPositionList = new List<int>();

            for (int i = 0; i < 81; i++)
            {
                sudokuPositionList.Add(0);
            }
            sudokuPositionList.Insert(5, 2);
            sudokuPositionList.Insert(6, 1);
            sudokuPositionList.Insert(11, 4);
            sudokuPositionList.Insert(14, 8);
            sudokuPositionList.Insert(15, 7);
            sudokuPositionList.Insert(19, 2);
            sudokuPositionList.Insert(21, 3);
            sudokuPositionList.Insert(24, 9);
            sudokuPositionList.Insert(27, 6);
            sudokuPositionList.Insert(29, 2);
            sudokuPositionList.Insert(32, 3);
            sudokuPositionList.Insert(34, 4);
            sudokuPositionList.Insert(46, 5);
            sudokuPositionList.Insert(48, 6);
            sudokuPositionList.Insert(51, 3);
            sudokuPositionList.Insert(53, 1);
            sudokuPositionList.Insert(56, 3);
            sudokuPositionList.Insert(59, 5);
            sudokuPositionList.Insert(61, 8);
            sudokuPositionList.Insert(65, 8);
            sudokuPositionList.Insert(66, 2);
            sudokuPositionList.Insert(69, 5);
            sudokuPositionList.Insert(74, 9);
            sudokuPositionList.Insert(75, 7);
            return sudokuPositionList;
        }
    }
}
