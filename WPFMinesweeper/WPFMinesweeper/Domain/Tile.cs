using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMinesweeper.ViewModels;

namespace WPFMinesweeper.Domain
{
    public class Tile {

        private bool _isMine;

        public Tile(int x, int y, bool isMine) {
            _isMine = isMine;
            _x = x;
            _y = y;
        }

        public bool IsMine {
            get { return _isMine; }
            set { _isMine = value; }
        }

        public bool IsRevealed {
            get { return _isRevealed; }
            set { _isRevealed = value; }
        }

        public int X {
            get { return _x; }
            set { _x = value; }
        }

        public int Y {
            get { return _y; }
            set { _y = value; }
        }

        public bool IsFlagged {
            get { return _isFlagged; }
            set { _isFlagged = value; }
        }

        private bool _isRevealed;
        private int _x;
        private int _y;
        private bool _isFlagged;
    }
}
