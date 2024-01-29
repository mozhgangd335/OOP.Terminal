using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.Entities
{
    internal class BuyTicket:Ticket
    {
        public BuyTicket(int travelId, int seatNumber) : base(travelId, seatNumber)
        {
        }
        public override void SetId()
        {
            if (OopTraveling._ReservaTickets.Count > 0)
            {
                TicketId = OopTraveling._BuyTickets.Last().TicketId + 1;
            }
            else
            {
                TicketId = 1;
            }
        }
    }
}
