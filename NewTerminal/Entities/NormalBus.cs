using NewTerminal.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.Entities
{
    internal class NormalBus:Bus
    {
        public NormalBus(int busid,string name) : base(busid,name, 44)
        {
        }
        public override void ShowSeats(int busId)
        {

            var travel = OopTraveling._TravelList.FirstOrDefault(t => t.BusId == busId);
            var seats = new List<SeatViewModel>();
            var buyTickets = OopTraveling._BuyTickets.Where(t => t.TravelId == travel.TravelId).ToList();
            foreach(var ticket in buyTickets)
            {
                var Buyseats=OopTraveling._SeatsList.Where(s=>s.TicketId==ticket.TicketId).ToList();
                foreach(var buySeat in Buyseats)
                {
                    seats.Add(new SeatViewModel("bb", buySeat.NumberOfSeat));
                }
            }
            var reservedTickets = OopTraveling._ReservaTickets.Where(t => t.TravelId == travel.TravelId).ToList();
            var resTickets = OopTraveling._BuyTickets.Where(t => t.TravelId == travel.TravelId).ToList();
            foreach (var ticket in resTickets)
            {
                var resSeats = OopTraveling._SeatsList.Where(s => s.TicketId == ticket.TicketId).ToList();
                foreach (var buySeat in resSeats)
                {
                    seats.Add(new SeatViewModel("rr", buySeat.NumberOfSeat));
                }
            }
            var seatsDetail = "";
            var seatDetail = "";


            for (int i = 1; i <= 44; i++)
            {
                if (i > 9)
                {
                    seatDetail =i.ToString();
                }
                else
                {
                    seatDetail ="0"+i.ToString();
                }
                foreach (var seat in seats)
                {
                    if (i == seat.SeatNum)
                    {
                        seatDetail = seat.Shape;
                    }
                }
                    if (i < 21 || i > 24)
                    {
                        if (i % 4 == 0)
                        {
                            seatDetail = seatDetail + "\n";
                        }
                        else if (i % 2 == 0)
                        {
                            seatDetail = seatDetail + "    ";
                        }
                        else
                        {
                            seatDetail = seatDetail + " ";
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                        seatDetail = seatDetail + "\n";
                        }
                        else
                        {
                            seatDetail = seatDetail + " ";
                        }
                    }
                    seatsDetail = seatsDetail + seatDetail;
                }
                Console.WriteLine(seatsDetail);
            }
        }
}
