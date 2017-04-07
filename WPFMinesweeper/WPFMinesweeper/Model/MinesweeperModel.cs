using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMinesweeper.Model
{
    class MinesweeperModel
    {
        private readonly Func<string, string> _convertion;

        public MinesweeperModel(Func<string, string> convertion)
        {
            _convertion = convertion;
        }

        public string ConvertText(string inputText)
        {
            return _convertion(inputText);
        }
    }
}
