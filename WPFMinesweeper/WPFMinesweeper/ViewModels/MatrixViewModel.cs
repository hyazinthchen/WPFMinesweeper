using System.Collections.Generic;

namespace WPFMinesweeper.ViewModels
{
    public class MatrixViewModel : BaseViewModel {

        private int _rowCount = 10;
        private int _columnCount = 10;

        public int RowCount
        {
            get { return _rowCount; }
            set { _rowCount = value; }
        }
        public int ColumnCount
        {
            get { return _columnCount; }
            set { _columnCount = value; }
        }
    }
}
