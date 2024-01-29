using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.ModelView
{
    internal class SeatViewModel
    {
        public SeatViewModel(string shape, int seatNum)
        {
            Shape = shape;
            SeatNum = seatNum;
        }

        public string Shape { get; set; }
        public int SeatNum { get; set; }
    }
}
