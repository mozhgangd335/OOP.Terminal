using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.Entities
{
    internal class Ticket
    {
        public int TicketId { get;protected set; }
        public int SeatNumber { get; set; }
        

        public int TravelId { get; set; }

        public Ticket(int travelId, int seatNumber)
        {
            SeatNumber = seatNumber;
            TravelId = travelId;
        }
        public virtual void SetId()
        {

        }

    }
}
