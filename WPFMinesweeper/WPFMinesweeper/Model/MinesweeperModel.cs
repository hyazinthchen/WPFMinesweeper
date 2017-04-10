using System;
using System.Collections;
using System.Collections.Generic;

namespace WPFMinesweeper.Model
{
    class MinesweeperModel
    {
        public static List<bool> listWithoutMines = new List<bool>();
        public static List<bool> listWithMines = new List<bool>();
        public static Random rnd = new Random();

        public static List<bool> GenerateRandomMines(List<bool> allFalseList, int mineCount)
        {
            for (int i = 0; i < mineCount; i++)
            {
                int index = rnd.Next(0, allFalseList.Count + 1);
                listWithoutMines.Insert(index, true);
            }
            listWithMines = listWithoutMines;
            return listWithMines;
        }

        public static List<bool> GenerateAllFalseList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                listWithoutMines.Add(false);
            }
            return listWithoutMines;
        }

        public static List<bool> GenerateMatrixMines(int fieldsize) {
            switch (fieldsize)
            {
                case 10:
                    GenerateRandomMines(GenerateAllFalseList(88), 12);
                    break;
                case 20:
                    GenerateRandomMines(GenerateAllFalseList(336), 64);
                    break;
                case 30:
                    GenerateRandomMines(GenerateAllFalseList(711), 189);
                    break;
            }
            return listWithMines;
        }
    }
}
