using System;
using System.Collections.Generic;

namespace PhoneNumber
{
    class Cell
    {
        public char value;
        public List<Cell> nodes = new List<Cell>();
    }
    class CellManipulation
    {
        public static Cell GetExactCell(List<Cell> cells, char digit)
        {
            foreach (Cell cell in cells)
            {
                if (cell.value == digit)
                    return cell;
            }
            return null;
        }
        public static bool CheckNumberForExistance(List<Cell> cells, char digit)
        {
            if (cells.Count == 0)
                return false;
            foreach (Cell cell in cells)
            {
                if (cell.value == digit)
                    return true;
            }
            return false;
        }
        public static bool CheckNumberForExistanceInNodes(Cell cell, char number)
        {
            return false;
        }
        public static void AddNumberToList(List<Cell> cells, char digit)
        {
            Cell newCell = new Cell();
            newCell.value = digit;
            cells.Add(newCell);
        }
    }
    class Solution
    {
        private static Cell phoneNumber = new Cell();
        private static int counterNewCells = 0;
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string telephone = Console.ReadLine();
                AddNumber(TelNumberDivision(telephone));
            }

            Console.WriteLine(counterNewCells);
        }
        private static char[] TelNumberDivision(string telNumber) => telNumber.ToCharArray();
        private static void AddNumber(char[] telNumber)
        {
            Cell headingCell = phoneNumber;
            for (int i = 0; i < telNumber.Length; i++)
            {
                char currentDigit = telNumber[i];
                if (headingCell == null)
                    return;
                if (!CellManipulation.CheckNumberForExistance(headingCell.nodes, currentDigit))
                {
                    CellManipulation.AddNumberToList(headingCell.nodes, currentDigit);
                    counterNewCells++;
                }
                headingCell = CellManipulation.GetExactCell(headingCell.nodes, currentDigit);
            }
        }
    }
}
