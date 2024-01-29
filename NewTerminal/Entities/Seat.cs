using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.Entities
{
    internal class Seat
    {
        public int Id { get; set; }
        public int NumberOfSeat { get; set; }
        public int TicketId { get; set; }

        public Seat(int number)
        {
            NumberOfSeat = number;

        }


    }
}
public enum TypeSeat
{
    BoughtSeat = 1,
    ReservedSeat
}
    

