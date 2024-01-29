using NewTerminal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal
{
    public static class OopTraveling
    {
        internal static List<Bus> _BusList = new List<Bus>();
        internal static List<Travel> _TravelList = new List<Travel>();
        internal static List<Ticket> _ReservaTickets = new List<Ticket>();
        internal static List<Ticket> _BuyTickets = new List<Ticket>();
        internal static List<Ticket> _BuyCancelList = new List<Ticket>();
        internal static List<Ticket> _ResCancelList = new List<Ticket>();
        internal static List<Seat> _SeatsList = new List<Seat>();
        internal static List<Report> _Reports = new List<Report>();


        public static void AddBus()
        {
            var name = Utility.GetString("enter name of bus");
            var type = Utility.GetInt("enter type of bus: 1=vipbus 2=normalbus");
            var Busid = Utility.GetInt("enter busid");


            while (!(type == 1 || type == 2))
            {
                Utility.GetString("Please choose 1 for vip or 2 for normal ");
                type = Utility.GetInt("enter type of bus: 1=vipbus 2=normalbus");

            }
            if (type == 1)
            {

                var Vipbus = new VipBus(Busid, name);
                _BusList.Add(Vipbus);

            }
            else if (type == 2)
            {
                var Normalbus = new NormalBus(Busid, name);
                _BusList.Add(Normalbus);
            }

        }


        public static void Travel()
        {
            var type = Utility.GetInt("pleaase choice your trqvel type:1.Vip 2.Normal");
            var capacity = type == 1 ? 30 : 44;
            ShowBusList(capacity);
            var busid = Utility.GetInt("enter busid:");
            var travelid = Utility.GetInt("enter travelid:");

            var OriginTravel = Utility.GetString("enter travel origin:");
            var DestinationTravel = Utility.GetString("enter travel destination:");
            var TravelCost = Utility.GetDouble("enter travel cost:");

            var bus = _BusList.FirstOrDefault(b => b.BusId == busid);
            if (bus == null)
            {
                throw new Exception("plese enter busid again");
            }
            else
            {
                Travel travel = new Travel(travelid, OriginTravel, DestinationTravel, TravelCost, busid);
                _TravelList.Add(travel);
                travel.SetPrice(TravelCost);
            }
        }
        public static void ReserveTickrt()
        {
            ShowTravels();

            var travelid = Utility.GetInt("please insert travelid:");
            var travel = _TravelList.FirstOrDefault(b => b.TravelId == travelid);
            if (travel == null)
            {
                throw new Exception("your travel is not found");
            }

            else
            {

                Bus bus = _BusList.FirstOrDefault(b => b.BusId == travel.BusId);

                bus.ShowSeats(bus.BusId);
                var SeatNum = Utility.GetInt("enter seatNumber:");

                if (SeatNum > 0 && SeatNum <= bus.Capacity)
                {
                    bool isSeatFull = false;
                    int totalTicketOfBus = 0;
                    foreach (ReserveTicket ticket in _ReservaTickets)
                    {
                        if (_TravelList[ticket.TravelId - 1].BusId == travel.BusId)
                        {
                            if (ticket.SeatNumber == SeatNum)
                            {
                                isSeatFull = true;
                                break;
                            }
                            totalTicketOfBus++;
                        }
                    }

                    foreach (var ticket in _BuyTickets)
                    {
                        if (_TravelList[ticket.TravelId - 1].BusId == travel.BusId)
                        {
                            if (ticket.SeatNumber == SeatNum)
                            {
                                isSeatFull = true;
                                break;
                            }
                            totalTicketOfBus++;
                        }
                    }

                    if (isSeatFull)
                    {
                        Console.WriteLine("your seat is full");
                    }
                    else if (totalTicketOfBus >= bus.Capacity)
                    {
                        Console.WriteLine("bus is full, choose another bus");
                    }
                    else
                    {
                        ReserveTicket reserveTicket = new ReserveTicket(travel.BusId, SeatNum);
                        reserveTicket.SetId();
                        _ReservaTickets.Add(reserveTicket);
                        var ticket = _ReservaTickets.Last();
                    }


                }



                else
                {
                    Console.WriteLine("seatNumebr is not valid.");

                }




            }
        }

        public static void BuyTicket()
        {

            ShowTravels();

            var travelid = Utility.GetInt("please insert travelid:");
            var travel = _TravelList.FirstOrDefault(b => b.TravelId == travelid);
            if (travel == null)
            {
                throw new Exception("your travel is not found");
            }

            else
            {

                Bus bus = _BusList.FirstOrDefault(b => b.BusId == travel.BusId);

                bus.ShowSeats(bus.BusId);
                var SeatNum = Utility.GetInt("enter seatNumber:");

                if (SeatNum > 0 && SeatNum <= bus.Capacity)
                {
                    bool isSeatFull = false;
                    int totalTicketOfBus = 0;
                    if (_BuyTickets.Count > 0)
                    {
                        foreach (var ticket in _BuyTickets)
                        {

                            if (ticket.SeatNumber == SeatNum)
                            {
                                isSeatFull = true;

                            }
                            totalTicketOfBus++;
                        }
                    }
                    if (_ReservaTickets.Count > 0)
                    {
                        foreach (var ticket in _ReservaTickets)
                        {

                            if (ticket.SeatNumber == SeatNum)
                            {
                                isSeatFull = true;

                            }
                            totalTicketOfBus++;
                        }
                    }
                    if (isSeatFull)
                    {
                        Console.WriteLine("your seat is full");
                    }
                    else if (totalTicketOfBus >= bus.Capacity)
                    {
                        Console.WriteLine("bus is full, choose another bus");
                    }
                    else
                    {
                        var buyTicket = new BuyTicket(travel.BusId, SeatNum);
                        buyTicket.SetId();
                        _BuyTickets.Add(buyTicket);
                        var ticket = _BuyTickets.Last();

                    }
                }

                else
                {
                    Console.WriteLine("seatNumebr is not valid.");

                }

            }
        }

        public static void CancelTicket()
        {

            ShowTravels();

            var travelid = Utility.GetInt("please insert travelid:");
            var travel = _TravelList.FirstOrDefault(b => b.TravelId == travelid);
            if (travel == null)
            {
                throw new Exception("your travel is not found");
            }

            else
            {
                var Buytickets = _BuyTickets.Where(b => b.TravelId == travelid).ToList();

                foreach (var buyTicket in Buytickets)
                {
                    Console.WriteLine($"Id:{buyTicket.TicketId} ");
                }

                var Restickets = _ReservaTickets.Where(b => b.TravelId == travelid).ToList();
                foreach (var resTicket in Restickets)
                {
                    Console.WriteLine($"Id:{resTicket.TicketId} ");
                }
                Console.WriteLine($"Enter TicketId");
                var ticketId = int.Parse(Console.ReadLine());
                var ticket = _BuyTickets.FirstOrDefault(t => t.TicketId == ticketId);
                if (ticket == null)
                {
                    throw new Exception("this number id not found");
                }
                else
                {
                    _BuyCancelList.Add(ticket);
                    _BuyTickets.Remove(ticket);
                }
                ticket = _ReservaTickets.FirstOrDefault(t => t.TicketId == ticketId);
                if (ticket == null)
                {
                    throw new Exception("this number id not found");
                }
                else
                {
                    _ResCancelList.Add(ticket);
                    _ReservaTickets.Remove(ticket);
                }
                //    ticket = _ReservaTickets.FirstOrDefault(t => t.TicketId == ticketId);
                //}
                //var seats = _SeatsList.Where(s => s.TicketId == ticketId);
                //if()


            }
        }
        public static void ShowBusList(int capacity)
        {
            int count = 1;
            foreach (var item in _BusList.Where(b => b.Capacity == capacity))
            {
                string busType = item is VipBus ? "vip" : "noraml";
                Console.WriteLine($"shomare: {count} {item.Name} {busType} busid={item.BusId}");
                count++;
            }
        }

        public static void ShowTravels()
        {

            if (_TravelList.Count == 0)
            {
                throw new Exception("please add travel");
            }
            else
            {
                int i = 0;
                foreach (var travel in _TravelList)
                {
                    i++;
                    Console.WriteLine($"{i}-busId:{travel.BusId} travelid:{travel.TravelId} {travel.Origin} {travel.Destination} ");
                }


            }
        }

        public static void Logging()
        {
            ShowTravels();
            var travelId = Utility.GetInt("Enter your TravelId");
            var travel = _TravelList.FirstOrDefault(t=>t.TravelId==travelId);
            var bus = _BusList.FirstOrDefault(b => b.BusId == travel.BusId);
            var buyTtickets=_BuyTickets.Where(t=>t.TravelId==travelId).ToList();
            var resTtickets=_ReservaTickets.Where(t=>t.TravelId==travelId).ToList();
            var resCancelTtickets=_ResCancelList.Where(t=>t.TravelId==travelId).ToList();
            var buyCancelTtickets=_BuyCancelList.Where(t=>t.TravelId==travelId).ToList();
            var seats = new List<Seat>();
           
            foreach(var ticket in buyTtickets)
            {
                seats.AddRange(_SeatsList.Where(s=>s.TicketId==ticket.TicketId));
            }
            foreach (var ticket in resTtickets)
            {
                seats.AddRange(_SeatsList.Where(s => s.TicketId == ticket.TicketId));
            }
            var seatNumber=seats.Count();
            var resCanceled = resCancelTtickets.Count();
            var buyCanceled = buyCancelTtickets.Count();
            double income = resCanceled * 2 / 10 * 3 / 10 * travel.Price + buyCanceled/10*travel.Price;
            int empty;
            if (typeof(VipBus)==bus.GetType())
            {
                empty=30-seatNumber;
            }
            else { empty=44-seatNumber; }
            Console.WriteLine($"incom:{income} emptySeat:{empty} CanceledReserve:{resCanceled} CanceledBuy:{buyCanceled}");

        }
    }
}








