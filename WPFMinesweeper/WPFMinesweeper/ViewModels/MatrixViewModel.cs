using System;
using System.Collections.Generic;

namespace WPFMinesweeper.ViewModels
{
    public class MatrixViewModel : BaseViewModel {

        private static int _rowCount = 10;
        private static int _columnCount = 10;
        private double _minePercentage = 0.12;
        private bool[,] field = new bool[_columnCount, _rowCount];
        private readonly Random rnd = new Random();
        private bool[,] _matrix;
        private List<bool> MineList;

        public bool[,] Matrix {
            get { return _matrix; }
            set { _matrix = value; }
        }

        public int RowCount{
            get { return _rowCount; }
            set { _rowCount = value; }
        }

        public int ColumnCount{
            get { return _columnCount; }
            set { _columnCount = value; }
        }

        public MatrixViewModel(){
            GenerateFields(field);
        }

        /// <summary>
        /// Berechnet die Matrix mit Minen
        /// </summary>
        /// <param name="fieldArray"></param>
        /// <returns></returns>
        private void GenerateFields(bool[,] fieldArray) {
            for (int i = 0; i < fieldArray.Length; i++)
            {
                int j = rnd.Next(9);
                int k = rnd.Next(9);
                if (fieldArray[j, k] == false) {
                    fieldArray[j, k] = rnd.NextDouble() < 1 - _minePercentage;
                    fieldArray = _matrix;
                }
            }
        }

        private void ConvertArrayToList() {
            MineList = new List<bool>(_matrix);
        }
    }
}
