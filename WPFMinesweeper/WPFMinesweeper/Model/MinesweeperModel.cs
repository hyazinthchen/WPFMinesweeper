namespace WPFMinesweeper.Model
{
    public class MinesweeperModel {
        private int _mines = 12;
        private int _flagsLeft;
        private int _columnCount = 10;
        private int _rowCount = 10;


        public MinesweeperModel(int flagsLeft) {
            FlagsLeft = flagsLeft;
        }

        /// <summary>
        ///     Anzahl noch verbleibender Flaggen
        /// </summary>
        public int FlagsLeft{
            get { return _flagsLeft; }
            set { _flagsLeft = value; }
        }

        /// <summary>
        /// Anzahl der zu setzenden Minen
        /// </summary>
        public int Mines{
            get { return _mines; }
        }

        /// <summary>
        ///     Anzahl der Reihen des Spielfelds
        /// </summary>
        public int RowCount {
            get { return _rowCount; }
        }

        /// <summary>
        ///     Anzahl der Spalten des Spielfelds
        /// </summary>
        public int ColumnCount {
            get { return _columnCount; }
        }


    }
}
