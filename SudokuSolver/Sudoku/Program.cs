using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> squares = createsStartConfiguration();
            List<int> squareWithConstantsOnly = getSudokuWithOriginalConstants(createsStartConfiguration());

            int currentSquare = 0;
            int maxSquareReached = 0;

            while(true)
            {
                squares[currentSquare]++;

                if (squares[currentSquare] > 9)
                {
                    squares[currentSquare] = 0;
                    currentSquare--;
                    while (squareWithConstantsOnly[currentSquare] != 0)
                    {
                        currentSquare--;
                    }
                    continue;
                }
                
                if (isSudokuValidSoFar(getSudokuWithOriginalConstants(squares)))
                {
                    currentSquare++;
                    if (currentSquare == 81)
                    {
                        break;
                    }

                    while (squareWithConstantsOnly[currentSquare] != 0)
                    {
                        currentSquare++;
                        if (currentSquare == 81)
                        {
                            break;
                        }
                    }
                    continue;
                }

                if (currentSquare > maxSquareReached)
                {
                    maxSquareReached = Math.Max(maxSquareReached, currentSquare);
                    Console.WriteLine(maxSquareReached);
                }
            }

            outputSudokuSquare(squares);
            Console.ReadLine();
        }
        

        static bool isSudokuValidSoFar(List<int> sudoku)
        {
            return matchesStartConfiguration(sudoku)
                && allRowsAreValid(sudoku)
                && allColumnsAreValid(sudoku)
                && valuesInSquaresAreValid(sudoku);
        }
        static bool allRowsAreValid(List<int> sudoku)
        {
            for (int j = 0; j < 9; j++)
            {
                List<int> valueTracker = new List<int>();
                for (int i = 0; i < 9; i++)
                {
                    var position = i + j * 9;
                    valueTracker.Add(sudoku[position]);
                }
                valueTracker.RemoveAll(p => p == 0);
                if (valueTracker.Count != valueTracker.Distinct().Count())
                {
                    return false;
                }
            }
            return true;
        }
        static bool allColumnsAreValid(List<int> sudoku)
        {
            for (int j = 0; j < 9; j++)
            {
                List<int> valueTracker = new List<int>();
                for (int i = 0; i < 9; i++)
                {
                    var position = i * 9 + j;
                    valueTracker.Add(sudoku[position]);
                }
                valueTracker.RemoveAll(p => p == 0);
                if (valueTracker.Count != valueTracker.Distinct().Count())
                {
                    return false;
                }
            }
            return true;
        }

        static bool valuesInSquaresAreValid(List<int> sudoku)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var isValid = squareIsValid(i * 3, j * 3, sudoku);
                    if (isValid == false) { return false; }
                }
            }
            return true;
        }

        static bool squareIsValid(int rowStartValue, int colStartValue, List<int> sudoku)
        {
            List<int> valueTracker = new List<int>();
            for (int i = rowStartValue; i < rowStartValue + 3; i++)
            {
                for (int j = colStartValue; j < colStartValue + 3; j++)
                {
                    var position = i + j * 9;
                    valueTracker.Add(sudoku[position]);
                }
            }
            valueTracker.RemoveAll(p => p == 0);
            if (valueTracker.Count != valueTracker.Distinct().Count())
            {
                return false;
            }
            return true;
        }

        public static List<int> createsStartConfiguration()
        {
            List<int> sudokuPositionList = new List<int>();

            for (int i = 0; i < 81; i++)
            {
                sudokuPositionList.Add(0);
            }

            return sudokuPositionList;
        }

        public static bool matchesStartConfiguration(List<int> sudokuPositionList)
        {
            return (sudokuPositionList[5] == 2 || sudokuPositionList[5] == 0)
             && (sudokuPositionList[6] == 1 || sudokuPositionList[6] == 0)
             && (sudokuPositionList[11] == 4 || sudokuPositionList[11] == 0)
             && (sudokuPositionList[14] == 8 || sudokuPositionList[14] == 0)
             && (sudokuPositionList[15] == 7 || sudokuPositionList[15] == 0)
             && (sudokuPositionList[19] == 2 || sudokuPositionList[19] == 0)
             && (sudokuPositionList[21] == 3 || sudokuPositionList[21] == 0)
             && (sudokuPositionList[24] == 9 || sudokuPositionList[24] == 0)
             && (sudokuPositionList[27] == 6 || sudokuPositionList[27] == 0)
             && (sudokuPositionList[29] == 2 || sudokuPositionList[29] == 0)
             && (sudokuPositionList[32] == 3 || sudokuPositionList[32] == 0)
             && (sudokuPositionList[34] == 4 || sudokuPositionList[34] == 0)
             && (sudokuPositionList[46] == 5 || sudokuPositionList[46] == 0)
             && (sudokuPositionList[48] == 6 || sudokuPositionList[48] == 0)
             && (sudokuPositionList[51] == 3 || sudokuPositionList[51] == 0)
             && (sudokuPositionList[53] == 1 || sudokuPositionList[53] == 0)
             && (sudokuPositionList[56] == 3 || sudokuPositionList[56] == 0)
             && (sudokuPositionList[59] == 5 || sudokuPositionList[59] == 0)
             && (sudokuPositionList[61] == 8 || sudokuPositionList[61] == 0)
             && (sudokuPositionList[65] == 8 || sudokuPositionList[65] == 0)
             && (sudokuPositionList[66] == 2 || sudokuPositionList[66] == 0)
             && (sudokuPositionList[69] == 5 || sudokuPositionList[69] == 0)
             && (sudokuPositionList[74] == 9 || sudokuPositionList[74] == 0)
             && (sudokuPositionList[75] == 7 || sudokuPositionList[75] == 0);
        }

        public static List<int> getSudokuWithOriginalConstants(List<int> sudokuPositionList)
        {
            sudokuPositionList[5] = 2;
            sudokuPositionList[6] = 1;
            sudokuPositionList[11] = 4;
            sudokuPositionList[14] = 8;
            sudokuPositionList[15] = 7;
            sudokuPositionList[19] = 2;
            sudokuPositionList[21] = 3;
            sudokuPositionList[24] = 9;
            sudokuPositionList[27] = 6;
            sudokuPositionList[29] = 2;
            sudokuPositionList[32] = 3;
            sudokuPositionList[34] = 4;
            sudokuPositionList[46] = 5;
            sudokuPositionList[48] = 6;
            sudokuPositionList[51] = 3;
            sudokuPositionList[53] = 1;
            sudokuPositionList[56] = 3;
            sudokuPositionList[59] = 5;
            sudokuPositionList[61] = 8;
            sudokuPositionList[65] = 8;
            sudokuPositionList[66] = 2;
            sudokuPositionList[69] = 5;
            sudokuPositionList[74] = 9;
            sudokuPositionList[75] = 7;
            return sudokuPositionList;
        }

        public static void outputSudokuSquare(List<int> sudoku)
        {
            Console.WriteLine("-----------");
            for(int i = 0; i < 9; i++)
            {
                string line = "|";
                for(int j = 0; j < 9; j++)
                {
                    line += sudoku[i * 9 + j];
                }
                line += "|";

                Console.WriteLine(line);
            }
            Console.WriteLine("-----------");
        }
    }
}
