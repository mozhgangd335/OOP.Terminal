using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTerminal.Entities
{
    internal class Travel
    {
    public int TravelId { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public double Price { get; set; }
        public int BusId { get; set; }
        public int shomare { get; set; }

        public Travel(int travelid, string origin, string destination, double price,int busid) {
            TravelId=travelid;
            Destination = destination;
            Origin = origin;
             Price=price;
            BusId=busid;
           
        }
        public void SetPrice(double price)
        {
            if (price < 0)
            {
                throw new Exception("The price cannot be less than zero");
            }

            Price = price;
        }
        }
    }

