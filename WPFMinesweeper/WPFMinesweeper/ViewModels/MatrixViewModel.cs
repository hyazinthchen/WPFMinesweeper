using System;
using System.Collections.Generic;

namespace WPFMinesweeper.ViewModels
{
    public class MatrixViewModel : BaseViewModel {

        private int _rowCount = 10;
        private int _columnCount = 10;
        private bool[,] field;
        private readonly Random rnd = new Random();
        private List<TileViewModel> _tiles = new List<TileViewModel>();
        private int _mines = 12;

        /// <summary>
        /// Liste von Buttons auf dem Spielfeld
        /// </summary>
        public List<TileViewModel> Tiles {
            get { return _tiles; }
            set { _tiles = value; }
        }

        /// <summary>
        /// Anzahl der Reihen des Spielfelds
        /// </summary>
        public int RowCount{
            get { return _rowCount; }
        }

        /// <summary>
        /// Anzahl der Spalten des Spielfelds
        /// </summary>
        public int ColumnCount{
            get { return _columnCount; }
        }

        /// <summary>
        /// Konstruktor für das MatrixViewModel
        /// </summary>
        public MatrixViewModel(){
            CalculateMines();
            GenerateMatrix();
        }

        /// <summary>
        /// Verteilt die Minen
        ///  </summary>
        /// <returns></returns>
        private void CalculateMines() {
            field = new bool[_columnCount,_rowCount];

            int minesCount = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (minesCount == _mines) {
                    break;
                }

                int mineX = rnd.Next(9);
                int mineY = rnd.Next(9);
                if (field[mineX, mineY] == false) {
                    field[mineX, mineY] = true;
                    minesCount++;
                }
            }
        }

        /// <summary>
        /// Generiert das Spielfeld
        /// </summary>
        private void GenerateMatrix() {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    bool isMine = field[i, j];
                    TileViewModel tileViewModel = new TileViewModel(i, j, isMine);
                    _tiles.Add(tileViewModel);
                }
            }
        }
    }
}
